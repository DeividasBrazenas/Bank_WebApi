namespace Bank.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Contracts;
    using Contracts.Request;
    using Contracts.Response;
    using Microsoft.AspNetCore.Mvc;
    using Middleware.Filters;
    using Services.Services.Account;

    [ProducesResponseType(typeof(ErrorDetailsResponse), 500)]
    [ApiController]
    [ValidateRequest]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("accounts")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Add([FromBody] AccountRequest request)
        {
            if (!Regex.IsMatch(request.Number, "^[A-Z]{2}[0-9]{18}$"))
            {
                return BadRequest("Account number is not in a valid format. " +
                                  "It should contain 2 capital letters in the beginning and 18 numbers");
            }

            return HandleResponse(await _accountService.CreateAccount(request));
        }

        [HttpGet]
        [Route("accounts")]
        [ProducesResponseType(typeof(List<AccountResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            return HandleResponse(await _accountService.GetAllAccounts());
        }

        [HttpGet]
        [Route("accounts/{id}")]
        [ProducesResponseType(typeof(AccountResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return HandleResponse(await _accountService.GetAccountById(id));
        }

        [HttpGet]
        [Route("accounts/customers/{id}")]
        [ProducesResponseType(typeof(List<AccountResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomerAccounts([FromRoute] int id)
        {
            return HandleResponse(await _accountService.GetAccountsByCustomerId(id));
        }

        [HttpPut]
        [Route("accounts/{id}")]
        [ProducesResponseType(typeof(AccountResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AccountRequest request)
        {
            if (!Regex.IsMatch(request.Number, "^[A-Z]{2}[0-9]{18}$"))
            {
                return BadRequest("Account number is not in a valid format. " +
                                  "It should contain 2 capital letters in the beginning and 18 numbers");
            }

            return HandleResponse(await _accountService.UpdateAccount(id, request));
        }

        [HttpDelete]
        [Route("accounts/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResponse(await _accountService.DeleteAccount(id));
        }

        private IActionResult HandleResponse(object response)
        {
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}