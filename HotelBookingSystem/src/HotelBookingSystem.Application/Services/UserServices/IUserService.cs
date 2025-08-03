using HotelBookingSystem.Application.Dtos.UserDtos;

namespace HotelBookingSystem.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<long> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(long userId);
        Task<ICollection<UserDto>> GetAllUsersAsync(int skip, int take);
        Task UpdateUserAsync(UserUpdateDto userDto);
        Task DeleteUserAsync(long userId);
    }
}