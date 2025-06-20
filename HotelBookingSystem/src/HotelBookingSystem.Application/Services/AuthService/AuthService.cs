using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task LogOutAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<long> SignUpUserAsync(CreateUserDto userCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
