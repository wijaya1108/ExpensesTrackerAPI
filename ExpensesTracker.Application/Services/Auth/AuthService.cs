using ExpensesTracker.Application.DTO.Auth;
using ExpensesTracker.Application.Services.JWT;
using ExpensesTracker.Application.Services.PasswordHash;
using ExpensesTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository userRepository, IPasswordHashService passwordHashService, TokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            var loginResponse = new LoginResponse(false);
            var existingUser = await _userRepository.GetUserByEmail(request.Username);

            if (existingUser != null)
            {
                bool isPasswordVarified = _passwordHashService.Verify(request.Password, existingUser.Password);

                if (isPasswordVarified)
                {
                    var token = _tokenService.CreateToken(existingUser.UID, existingUser.Email, true);

                    loginResponse.Token = token;
                    loginResponse.Email = existingUser.Email;
                    loginResponse.UserUID = existingUser.UID;
                    loginResponse.Success = true;
                    return loginResponse;
                }
                else
                {
                    loginResponse.Errors.Add("Invalid password");
                    return loginResponse;
                }
            }

            loginResponse.Errors.Add("Username does not exist");
            return loginResponse;
        }
    }
}
