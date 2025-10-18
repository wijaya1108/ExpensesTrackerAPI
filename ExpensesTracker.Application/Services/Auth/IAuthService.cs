using ExpensesTracker.Application.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginUser(LoginRequest request);
    }
}
