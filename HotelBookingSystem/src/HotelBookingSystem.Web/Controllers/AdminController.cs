using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBookingSystem.Web.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService UserService;

        public AdminController(IUserService userService)
        {
            UserService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createUser")]
        public async Task<long> CreateUserAsync(CreateUserDto createUserDto)
        {
            return await UserService.CreateUserAsync(createUserDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getUserById")]
        public async Task<UserDto> GetUserByIdAsync(long roomId)
        {
            return await UserService.GetUserByIdAsync(roomId);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllUsers")]
        public async Task<ICollection<UserDto>> GetAllUsersAsync([FromQuery] int skip, int take)
        {
            return await UserService.GetAllUsersAsync(skip, take);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updateUser")]
        public async Task UpdateUserAsync(UserDto userDto)
        {
            await UserService.UpdateUserAsync(userDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteUser")]
        public async Task DeleteUserAsync([FromQuery] long userId)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            await UserService.DeleteUserAsync(userId);
        }
    }
}
