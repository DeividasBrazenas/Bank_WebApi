namespace Bank.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;
    using Contracts.Request;
    using Contracts.Response;
    using Microsoft.AspNetCore.Mvc;
    using Middleware.Filters;
    using Services.Mappers;
    using Services.Services.Loan;

    [ProducesResponseType(typeof(ErrorDetailsResponse), 500)]
    [ApiController]
    [ValidateRequest]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [Route("loans")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Add([FromBody] LoanRequest request)
        {
            if (request.InterestRate < 0 || request.InterestRate > 1)
            {
                return BadRequest("Interest rate should be between 0 and 1");
            }

            if (request.LoanStart > request.LoanEnd)
            {
                return BadRequest("Loan end date should be later than loan start date");
            }

            return HandleResponse(await _loanService.CreateLoan(request));
        }

        [HttpGet]
        [Route("loans")]
        [ProducesResponseType(typeof(List<LoanResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            return HandleResponse(await _loanService.GetAllLoans());
        }

        [HttpGet]
        [Route("loans/{id}")]
        [ProducesResponseType(typeof(LoanResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return HandleResponse(await _loanService.GetLoanById(id));
        }

        [HttpGet]
        [Route("loans/customers/{id}")]
        [ProducesResponseType(typeof(List<AccountResponse>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomerAccounts([FromRoute] int id)
        {
            return HandleResponse(await _loanService.GetLoansByCustomerId(id));
        }

        [HttpPut]
        [Route("loans/{id}")]
        [ProducesResponseType(typeof(LoanResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] LoanRequest request)
        {
            if (request.InterestRate < 0 || request.InterestRate > 1)
            {
                return BadRequest("Interest rate should be between 0 and 1");
            }

            if (request.LoanStart > request.LoanEnd)
            {
                return BadRequest("Loan end date should be later than loan start date");
            }

            return HandleResponse(await _loanService.UpdateLoan(id, request));
        }

        [HttpDelete]
        [Route("loans")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return HandleResponse(await _loanService.DeleteLoan(id));
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