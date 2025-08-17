using ExpensesTracker.Application.DTO.User;
using ExpensesTracker.Application.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllUsers(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{uid:guid}")] //to ensure only valid guids are accepted
        public async Task<ActionResult<UserResponse>> GetUserById(Guid uid, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserById(uid, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUser(request, cancellationToken);
            return CreatedAtAction(nameof(GetUserById), new { uid = result.UID }, result);
        }

        [HttpPut("{uid:guid}")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest request, Guid uid, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUser(request, uid, cancellationToken);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> DeleteUser(Guid uid, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUser(uid, cancellationToken);
            return result ? NoContent() : NotFound();
        }
    }
}
