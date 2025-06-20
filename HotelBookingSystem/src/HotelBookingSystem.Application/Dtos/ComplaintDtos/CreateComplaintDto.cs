using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Dtos.ComplaintDtos;
public class CreateComplaintDto
{
    public long HotelId { get; set; }
    public long UserId { get; set; }
    public string Message { get; set; }
    

}
