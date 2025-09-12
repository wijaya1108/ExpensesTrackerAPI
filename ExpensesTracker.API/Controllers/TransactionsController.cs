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

            return CreatedAtAction(nameof(GetTransactionByUID), new { transactionUID = result.UID, }, result);
        }

        [HttpGet("{userUID:guid}/{transactionTypeId:int}")]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetTransactionsByUserAndTransactionID(Guid userUID, int transactionTypeId)
        {
            var result = await _transactionService.GetTransactionsByUserAndTransactionTypeID(userUID, transactionTypeId);
            return Ok(result);
        }

        [HttpGet("{transactionUID:guid}")]
        public async Task<ActionResult<TransactionResponse>> GetTransactionByUID(Guid transactionUID)
        {
            var result = await _transactionService.GetTransactionByUID(transactionUID);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{transactionUID:guid}")]
        public async Task<ActionResult> UpdateTransaction([FromBody] UpdateTransactionRequest request, Guid transactionUID)
        {
            var result = await _transactionService.UpdateTransaction(request, transactionUID);
            return result ? NoContent() : NotFound();
        }
    }
}
