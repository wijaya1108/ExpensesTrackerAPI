using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.Transactions
{
    public record TransactionResponse(
        Guid UID,
        string Name,
        string? Description,
        decimal Amount,
        DateTime CreatedDate,
        DateTime ModifiedDate,
        Guid UserUID,
        int TransactionTypeId);
}
