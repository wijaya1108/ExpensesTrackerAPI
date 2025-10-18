using ExpensesTracker.Application.DTO.Auth;
using ExpensesTracker.Application.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginUser([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginUser(request);
            if (result.Success)
                return Ok(result);
            return Unauthorized(result); //check your username or password
        }
    }
}
