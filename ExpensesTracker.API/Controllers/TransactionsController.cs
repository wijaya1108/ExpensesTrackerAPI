using ExpensesTracker.Application.DTO.Transactions;
using ExpensesTracker.Application.Services.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            var result = await _transactionService.InsertTransaction(request);
            return Ok(result);
        }

        [HttpGet("{userUID:guid}/{transactionTypeId:int}")]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetTransactionsByUserAndTransactionID(Guid userUID, int transactionTypeId)
        {
            var result = await _transactionService.GetTransactionsByUserAndTransactionTypeID(userUID, transactionTypeId);
            return result;
        }
    }
}
