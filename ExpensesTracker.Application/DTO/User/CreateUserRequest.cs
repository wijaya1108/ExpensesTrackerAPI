using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.User
{
    public record CreateUserRequest(
        string? FirstName,

        [Required(ErrorMessage = "Last name is required")]
        string LastName,

        string? Address,

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        string Email,

        [Required(ErrorMessage = "Password is required")]
        [MinLength(4, ErrorMessage = "Password must be at least contain 4 characters")]
        string Password
        );
}
