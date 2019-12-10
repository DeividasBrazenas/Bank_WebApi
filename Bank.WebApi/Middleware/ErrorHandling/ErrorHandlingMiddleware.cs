namespace Bank.WebApi.Middleware.ErrorHandling
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Contracts.Response;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Extensions;
    using Newtonsoft.Json;
    using Serilog;
    using Services.Exceptions;

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                await HandleBusinessExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await LogErrorExceptionWithRequestBody(context, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleBusinessExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            _logger.Error(exception.Message);

            return context.Response.WriteAsync(new ErrorDetailsResponse
            {
                Message = exception.Message
            }.ToString());
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorMessage = "Internal server error happened. Please contact support";

            return context.Response.WriteAsync(new ErrorDetailsResponse
            {
                Message = errorMessage
            }.ToString());
        }

        // There's a bug in .NET Core 3.0, which doesn't read the request body (https://github.com/aspnet/AspNetCore/issues/14396#issuecomment-538016232)
        private async Task LogErrorExceptionWithRequestBody(HttpContext context, Exception exception)
        {
            context.Request.EnableBuffering();
            context.Request.Body.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();

            _logger.Error(
                exception,
                $"WebApi exception, Method: {{method}}, Content: {{faultMessage}}",
                $"{context.Request.Method} {context.Request.GetDisplayUrl()}",
                JsonConvert.SerializeObject(body));

            context.Request.Body.Seek(0, SeekOrigin.Begin);
        }
    }
}