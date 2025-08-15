using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.User
{
    public record UpdateUserRequest(
        string FirstName,

        [Required(ErrorMessage = "Last name is required")]
        string LastName,

        string Address,

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        string Email
        );
}
