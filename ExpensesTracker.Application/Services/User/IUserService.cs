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
        Task<List<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUserById(Guid uid);
        Task<UserResponse> CreateUser(CreateUserRequest request);
    }
}
