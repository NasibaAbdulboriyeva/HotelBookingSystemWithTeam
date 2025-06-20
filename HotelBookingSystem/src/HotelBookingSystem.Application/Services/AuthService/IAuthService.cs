using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<long> SignUpUserAsync(CreateUserDto userCreateDto);
        Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto);
        Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request);
        Task LogOutAsync(string token);
    }
}
