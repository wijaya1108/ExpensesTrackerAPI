using ExpensesTracker.Application.DTO.User;
using ExpensesTracker.Application.Mappers;
using ExpensesTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            var user = request.MapToUser(); //extension method to map to user model
            var newUser = await _userRepository.InsertUser(user);
            UserResponse userResponse = newUser.MapToUserResponse();
            return userResponse;

            //todo - hash password, validation
        }
    }
}
