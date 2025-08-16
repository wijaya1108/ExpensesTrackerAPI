using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.User
{
    public record UserResponse(
        Guid UID,
        string? FirstName,
        string LastName,
        string? Address,
        string Email,
        DateTime CreatedDate,
        DateTime ModifiedDate
        );
}
