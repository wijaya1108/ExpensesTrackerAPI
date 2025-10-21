using ExpensesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.JWT
{
    public interface ITokenService
    {
        string CreateToken(Domain.Entities.User user);
    }
}
