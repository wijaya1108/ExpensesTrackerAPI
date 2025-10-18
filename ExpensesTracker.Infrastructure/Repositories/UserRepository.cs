using ExpensesTracker.Domain.Entities;
using ExpensesTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                .AsNoTracking()
                .Where(u => !u.IsDeleted)
                .OrderByDescending(u => u.CreatedDate)
                .ToListAsync(cancellationToken);

            return users;
        }

        public async Task<User> GetUserById(Guid uid, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UID == uid && !u.IsDeleted, cancellationToken);

            return user;
        }

        public async Task<User> InsertUser(User user, CancellationToken cancellationToken)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task<bool> UpdateUser(User user, CancellationToken cancellationToken)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UID == user.UID && !u.IsDeleted, cancellationToken);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;
                existingUser.ModifiedDate = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUser(Guid uid, CancellationToken cancellationToken)
        {
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.UID == uid && !u.IsDeleted, cancellationToken);

            if (existingUser != null)
            {
                existingUser.IsDeleted = true;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Email == email && !u.IsDeleted)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
