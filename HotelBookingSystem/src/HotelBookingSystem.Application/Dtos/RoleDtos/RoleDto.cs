namespace HotelBookingSystem.Application.Dtos.RoleDtos;
public class RoleDto
{
    public long RoleId { get; set; }
    public string RoleName { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public long HotelId { get; set; }
}
