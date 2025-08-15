using ExpensesTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid uid);
        Task<User> InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(Guid uid);
    }
}
