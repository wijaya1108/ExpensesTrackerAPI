using ExpensesTracker.Application.DTO.User;
using ExpensesTracker.Application.Mappers;
using ExpensesTracker.Application.Services.PasswordHash;
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
        private readonly IPasswordHashService _passwordHashService;

        public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
        }

        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            var user = request.MapToUser(); //extension method to map to user model
            user.Password = _passwordHashService.HashPassword(user.Password);
            var newUser = await _userRepository.InsertUser(user);

            UserResponse userResponse = newUser.MapToUserResponse();
            return userResponse;
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var userResponseList = new List<UserResponse>();
            var users = await _userRepository.GetAllUsers();

            if (users != null && users.Any())
            {
                foreach (var user in users)
                {
                    userResponseList.Add(user.MapToUserResponse());
                }

                return userResponseList;
            }

            return userResponseList;
        }
    }
}
