namespace Bank.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Contracts.Request;
    using Contracts.Response;
    using Microsoft.AspNetCore.Mvc;
    using Middleware.Filters;
    using Services.Services.Customer;

    [ProducesResponseType(typeof(ErrorDetailsResponse), 500)]
    [ApiController]
    [ValidateRequest]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("customers")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Add([FromBody] CustomerRequest request)
        {
            if (!Regex.IsMatch(request.PersonalNumber, "^[0-9]{11}$"))
            {
                return BadRequest("Personal number is not in a valid format. It should contain 11 digits");
            }

            return HandleResponse(await _customerService.CreateCustomer(request));
        }

        [HttpGet]
        [Route("customers")]
        [ProducesResponseType(typeof(List<CustomerResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            return HandleResponse(await _customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("customers/{id}")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return HandleResponse(await _customerService.GetCustomerById(id));
        }

        [HttpPut]
        [Route("customers/{id}")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] CustomerRequest request)
        {
            if (!Regex.IsMatch(request.PersonalNumber, "^[0-9]{11}$"))
            {
                return BadRequest("Personal number is not in a valid format. It should contain 11 digits");
            }

            return HandleResponse(await _customerService.UpdateCustomer(id, request));
        }

        [HttpDelete]
        [Route("customers/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResponse(await _customerService.DeleteCustomer(id));
        }

        [HttpGet]
        [Route("customers/{id}/accounts")]
        [ProducesResponseType(typeof(List<AccountResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAccounts([FromRoute] int id)
        {
            return HandleResponse(await _customerService.GetCustomerAccounts(id));
        }

        [HttpGet]
        [Route("customers/{id}/loans")]
        [ProducesResponseType(typeof(List<LoanResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLoans([FromRoute] int id)
        {
            return HandleResponse(await _customerService.GetCustomerLoans(id));
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