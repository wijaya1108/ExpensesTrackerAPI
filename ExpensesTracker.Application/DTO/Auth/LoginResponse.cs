using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.DTO.Auth
{
    public class LoginResponse
    {
        public LoginResponse(bool success)
        {
            this.Success = success;
        }

        public LoginResponse() { }

        public string? Token { get; set; }
        public string? Email { get; set; }
        public Guid? UserUID { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public bool Success { get; set; }
    }
}
