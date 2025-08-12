using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.PasswordHash
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
        bool Verify(string password, string passowrdHash);
    }
}
