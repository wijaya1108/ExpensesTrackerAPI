using ExpensesTracker.Application.Services.JWT;
using ExpensesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        public string CreateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
