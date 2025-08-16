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

        public async Task<List<UserResponse>> GetAllUsers(CancellationToken cancellationToken)
        {
            var userResponseList = new List<UserResponse>();
            var users = await _userRepository.GetAllUsers(cancellationToken);

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

        public async Task<UserResponse?> GetUserById(Guid uid, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(uid, cancellationToken);

            return user?.MapToUserResponse(); //returns null if user is null
        }

        public async Task<UserResponse> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.MapToUser(); //extension method to map to user model
            user.Password = _passwordHashService.HashPassword(user.Password);
            var newUser = await _userRepository.InsertUser(user, cancellationToken);

            UserResponse userResponse = newUser.MapToUserResponse();
            return userResponse;
        }

        public async Task<bool> UpdateUser(UpdateUserRequest request, Guid uid, CancellationToken cancellationToken)
        {
            var user = request.MapToUser(uid);
            var result = await _userRepository.UpdateUser(user, cancellationToken);
            return result;
        }

        public async Task<bool> DeleteUser(Guid uid, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteUser(uid, cancellationToken);
            return result;
        }
    }
}
