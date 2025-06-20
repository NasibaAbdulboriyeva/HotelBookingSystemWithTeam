using FluentValidation;
using HotelBookingSystem.Application.Dtos.LoginResponseDto;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.Services.AuthService;
using HotelBookingSystem.Core.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Sign Up
    [HttpPost("signup")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody] CreateUserDto dto)
    {
        try
        {
            var userId = await _authService.SignUpUserAsync(dto);
            return Ok(new { Message = "User created", UserId = userId });
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
    }

    // Log In
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
    {
        try
        {
            var response = await _authService.LoginUserAsync(dto);
            return Ok(response);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(new { ex.Message });
        }
    }

    // Refresh Token
    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshRequestDto dto)
    {
        try
        {
            var response = await _authService.RefreshTokenAsync(dto);
            return Ok(response);
        }
        catch (ForbiddenException ex)
        {
            return Forbid(ex.Message);
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(new { ex.Message });
        }
    }

    // Log Out
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Logout([FromBody] string refreshToken)
    {
        await _authService.LogOutAsync(refreshToken);
        return Ok(new { Message = "Logged out successfully" });
    }
}
