using HotelBookingSystem.Application.Dtos;
using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.Helpers.Security;
using HotelBookingSystem.Application.Services.TokenService;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using System.Security.Claims;

namespace HotelBookingSystem.Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository UserRepository;
        private readonly IRefreshTokenRepository RefreshTokenRepository;
        private readonly ITokenService TokenService;



        public AuthService(ITokenService tokenService, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            TokenService = tokenService;
            UserRepository = userRepository;
            RefreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = await UserRepository.SelectUserByUserNameAsync(userLoginDto.UserName);

            var checkUserPassword = PasswordHasher.Verify(userLoginDto.Password, user.Password, user.Salt);

            if (!checkUserPassword)
            {
                throw new UnauthorizedException("UserName or password incorrect");
            }

            var userGetDto = new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = (UserRoleDto)user.Role,
            };

            var token = TokenService.GenerateToken(userGetDto);
            var refreshToken = TokenService.GenerateRefreshToken();

            var refreshTokenToDB = new RefreshToken()
            {
                Token = refreshToken,
                ExpirationDate = DateTime.UtcNow.AddDays(21),
                IsRevoked = false,
                UserId = user.UserId
            };

            await RefreshTokenRepository.InsertRefreshTokenAsync(refreshTokenToDB);
            await RefreshTokenRepository.SaveChangesAsync(); 

            var loginResponseDto = new LoginResponseDto()
            {
                AccessToken = token,
                RefreshToken = refreshToken,
                TokenType = "Bearer",
                ExpiresInMinutes = 24
            };


            return loginResponseDto;
        }

        public async Task LogOutAsync(string token)
        {
            await RefreshTokenRepository.RemoveRefreshTokenAsync(token);
            await RefreshTokenRepository.SaveChangesAsync();
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request)
        {
            ClaimsPrincipal? principal = TokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            if (principal == null) throw new ForbiddenException("Invalid access token.");


            var userClaim = principal.FindFirst(c => c.Type == "UserId");
            var userId = long.Parse(userClaim.Value);


            var refreshToken = await RefreshTokenRepository.SelectRefreshTokenAsync(request.RefreshToken, userId);
            if (refreshToken == null || refreshToken.ExpirationDate < DateTime.UtcNow || refreshToken.IsRevoked)
                throw new UnauthorizedException("Invalid or expired refresh token.");

            refreshToken.IsRevoked = true;

            var user = await UserRepository.SelectByIdAsync(userId);

            var userGetDto = new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = (UserRoleDto)user.Role,
            };

            var newAccessToken = TokenService.GenerateToken(userGetDto);
            var newRefreshToken = TokenService.GenerateRefreshToken();

            var refreshTokenToDB = new RefreshToken()
            {
                Token = newRefreshToken,
                ExpirationDate = DateTime.UtcNow.AddDays(21),
                IsRevoked = false,
                UserId = user.UserId
            };

            await RefreshTokenRepository.InsertRefreshTokenAsync(refreshTokenToDB);
            await RefreshTokenRepository.SaveChangesAsync();


            return new LoginResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                TokenType = "Bearer",
                ExpiresInMinutes = 900
            };
        }

        public async Task<long> SignUpUserAsync(CreateUserDto userCreateDto)
        {
            var tupleFromHasher = PasswordHasher.Hasher(userCreateDto.Password);
            var user = new User()
            {
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                UserName = userCreateDto.UserName,
                Email = userCreateDto.Email,
                PhoneNumber = userCreateDto.PhoneNumber,
                Password = tupleFromHasher.Hash,
                Salt = tupleFromHasher.Salt,
                Role = UserRole.User,
            };

           await UserRepository.InsertAsync(user);
           await UserRepository.SaveChangesAsync();
            return user.UserId;
        }
    }
}

