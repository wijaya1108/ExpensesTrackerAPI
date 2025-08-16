using ExpensesTracker.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.User
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllUsers(CancellationToken cancellationToken);
        Task<UserResponse?> GetUserById(Guid uid, CancellationToken cancellationToken);
        Task<UserResponse> CreateUser(CreateUserRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateUser(UpdateUserRequest request, Guid uid, CancellationToken cancellationToken);
        Task<bool> DeleteUser(Guid uid, CancellationToken cancellationToken);
    }
}
