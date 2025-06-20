using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.Mappings;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.Helpers.Security;
using HotelBookingSystem.Application.Services.TokenService;
using HotelBookingSystem.Application.Validators.UserValidator;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IRefreshTokenRepository RefreshTokenRepository;
        private readonly IUserRepository UserRepository;
        private readonly ITokenService TokenService;
        private readonly IValidator<CreateUserDto> UserValidator;
        private readonly IValidator<UserLoginDto> UserLoginValidator;
        private readonly IMapper mapper;
        public AuthService(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, ITokenService tokenService, IValidator<CreateUserDto> userValidator, IValidator<UserLoginDto> userLoginValidator)
        {
            RefreshTokenRepository = refreshTokenRepository;
            UserRepository = userRepository;
            TokenService = tokenService;
            UserValidator = userValidator;
            UserLoginValidator = userLoginValidator;
        }
        public async Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var validationResult = await UserLoginValidator.ValidateAsync(userLoginDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = await UserRepository.SelectByEmailAsync(userLoginDto.Email);

            var checkUserPassword = PasswordHasher.Verify(userLoginDto.Password, user.Password, user.Salt);

            if (checkUserPassword == false)
            {
                throw new UnauthorizedException("Email or password incorrect");
            }

            var userGetDto = mapper.Map<UserDto>(user);

            var accessToken = TokenService.GenerateToken(userGetDto);

            var refreshToken = CreateRefreshToken(Guid.NewGuid().ToString(), user.UserId);

            await RefreshTokenRepository.InsertRefreshTokenAsync(refreshToken);

            var loginResponseDto = new LoginResponseDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                TokenType = "Bearer",
                ExpiresInMinutes = 25,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(25)
            };

            return loginResponseDto;
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            if (principal == null) throw new ForbiddenException("Invalid access token.");

            var userClaim = principal.FindFirst(c => c.Type == "UserId");
            var userId = long.Parse(userClaim.Value);

            var refreshToken = await RefreshTokenRepository.SelectRefreshTokenAsync(request.RefreshToken, userId);
            if (refreshToken == null || refreshToken.ExpirationDate < DateTime.UtcNow || refreshToken.IsRevoked)
                throw new UnauthorizedException("Invalid or expired refresh token.");

            refreshToken.IsRevoked = true;
            await RefreshTokenRepository.UpdateRefreshTokenAsync(refreshToken);

            var user = await UserRepository.SelectByIdAsync(userId);

            var userGetDto = mapper.Map<UserDto>(user);

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

            return new LoginResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                TokenType = "Bearer",
                ExpiresInMinutes = 25,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(25)
            };
        }

        public async Task<long> SignUpUserAsync(CreateUserDto userCreateDto)
        {
            var validationResult = await UserValidator.ValidateAsync(userCreateDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var tupleFromHasher = PasswordHasher.Hasher(userCreateDto.Password);

            var user = mapper.Map<User>(userCreateDto);
            user.Salt = tupleFromHasher.Salt;
            user.PasswordHash = tupleFromHasher.Hash;

            var userId = await UserRepository.InsertAsync(user);

            var refreshToken = CreateRefreshToken(Guid.NewGuid().ToString(), userId);

            await RefreshTokenRepository.InsertRefreshTokenAsync(refreshToken);

            var accessToken = TokenService.GenerateToken(mapper.Map<UserDto>(user));
            return userId;
        }

        public async Task LogOutAsync(string token)
        {
            await RefreshTokenRepository.RemoveRefreshTokenAsync(token);
        }

        private static RefreshToken CreateRefreshToken(string token, long userId)
        {
            return new RefreshToken
            {
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddDays(21),
                IsRevoked = false,
                UserId = userId
            };
        }
    }
}
