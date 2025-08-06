using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;

namespace HotelBookingSystem.Application.Services.AuthService
{

    public interface IAuthService
    {
        Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto);
        Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request);
        Task<long> SignUpUserAsync(CreateUserDto userCreateDto);
        Task LogOutAsync(string token);
    }
    }

