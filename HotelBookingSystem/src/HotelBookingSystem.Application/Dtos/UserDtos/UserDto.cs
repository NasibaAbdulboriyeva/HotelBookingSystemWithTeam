using HotelBookingSystem.Application.Dtos.RoleDtos;

namespace HotelBookingSystem.Application.Dtos.UserDtos;
public class UserDto
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public UserRoleDto Role { get; set; }

}
