using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Dtos.ComplaintDtos;
public class ComplaintDto
{
    public long ComplaintId { get; set; }
    public string Message { get; set; }
    public ComplaintStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

}


