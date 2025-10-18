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
        Task<List<User>> GetAllUsers(CancellationToken cancellationToken);
        Task<User> GetUserById(Guid uid, CancellationToken cancellationToken);
        Task<User> InsertUser(User user, CancellationToken cancellationToken);
        Task<bool> UpdateUser(User user, CancellationToken cancellationToken);
        Task<bool> DeleteUser(Guid uid, CancellationToken cancellationToken);
        Task<User?> GetUserByEmail(string email);
    }
}
