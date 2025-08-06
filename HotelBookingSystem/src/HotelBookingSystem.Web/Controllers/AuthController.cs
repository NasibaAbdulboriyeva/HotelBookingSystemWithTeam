using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService AuthService;
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost("sign-up")]
        public async Task<long> SignUp(CreateUserDto userCreateDto)
        {
            return await AuthService.SignUpUserAsync(userCreateDto);
        }

        [HttpPost("login")]
        public async Task<LoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            return await AuthService.LoginUserAsync(userLoginDto);
        }

        [HttpPost("refresh-token")]
        public async Task<LoginResponseDto> RefreshToken(RefreshRequestDto request)
        {
            return await AuthService.RefreshTokenAsync(request);
        }

        [HttpDelete("log-out")]
        public async Task LogOut(string token)
        {
            await AuthService.LogOutAsync(token);
        }
    }
}

