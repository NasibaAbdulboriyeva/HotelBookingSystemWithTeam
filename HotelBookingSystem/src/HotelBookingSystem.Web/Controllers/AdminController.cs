using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AdminController
    {
        private readonly IUserService UserService;

        public AdminController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost("createUser")]
        public async Task<long> CreateUserAsync(CreateUserDto createUserDto)
        {
            return await UserService.CreateUserAsync(createUserDto);
        }

        [HttpGet("getUserById")]
        public async Task<UserDto> GetUserByIdAsync(long roomId)
        {
            return await UserService.GetUserByIdAsync(roomId);
        }

        [HttpGet("getAllUsers")]
        public async Task<ICollection<UserDto>> GetAllUsersAsync([FromQuery] int skip, int take)
        {
            return await UserService.GetAllUsersAsync(skip, take);
        }

        [HttpPut("updateUser")]
        public async Task UpdateUserAsync(UserDto userDto)
        {
            await UserService.UpdateUserAsync(userDto);
        }

        [HttpDelete("deleteUser")]
        public async Task DeleteUserAsync([FromQuery] long userId)
        {
            await UserService.DeleteUserAsync(userId);
        }
    }
}
