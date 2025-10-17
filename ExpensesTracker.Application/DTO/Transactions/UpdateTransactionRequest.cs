using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.Transactions
{
    public record UpdateTransactionRequest(

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        string Name,

        string? Description,

        decimal Amount
        );
}
