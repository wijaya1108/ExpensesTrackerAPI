using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.Transactions
{
    public record CreateTransactionRequest(
        string Name,
        string? Description,
        decimal Amount,
        Guid UserUID,
        int TransactionTypeId);
}
