using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.Auth
{
    public record LoginRequest(
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        string Username,

        [Required(ErrorMessage = "Password is required")]
        string Password
        );
}
