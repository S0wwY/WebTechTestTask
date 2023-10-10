using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTechTestTask.Application.Interfaces;
using WebTechTestTask.Application.ViewModels.UserViewModels;
using WebTechTestTask.Models.Pagination;

namespace WebTechTestTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<PagedList<UserVm>> GetUsers([FromQuery] UserParameters userParameters)
        {
            var users = await _userService.GetFilteredUsersAsync(userParameters);

            return users;
        }

        [Authorize]
        [HttpGet("GetUserById/{id}")]
        public async Task<UserVm> GetUserById(int id)
        {
            var userEntity = await _userService.GetUserByIdAsync(id);

            return userEntity;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreationVm newUser)
        {
            await _userService.CreateUserAsync(newUser);

            return Ok();
        }

        [HttpPut("UpdateUserById/{id}")]
        public async Task<IActionResult> UpdateUserById(int id, [FromBody] UserForUpdateVm updatedUser)
        {
            await _userService.UpdateUserAsync(id, updatedUser);

            return Ok();
        }

        [HttpPost("AddRoleForUser/{id}")]
        public async Task<IActionResult> AddRoleForUser(int id,[FromBody] ICollection<int> newRoles)
        {
            await _userService.AddRoleForUser(id, newRoles);

            return Ok();
        }

        [HttpDelete("DeleteUserById/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            await _userService.DeleteUserByIdAsync(id);

            return Ok();
        }
    }
}
