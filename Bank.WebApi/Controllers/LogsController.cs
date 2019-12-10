namespace Bank.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts.Response;
    using Microsoft.AspNetCore.Mvc;
    using Services.Services.Logs;

    [ProducesResponseType(typeof(ErrorDetailsResponse), 500)]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        [Route("logs")]
        [ProducesResponseType(typeof(List<LogResponse>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(_logService.GetLogs());
        }
    }
}