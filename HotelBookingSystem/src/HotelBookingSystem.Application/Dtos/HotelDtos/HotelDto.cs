namespace HotelBookingSystem.Application.Dtos.HotelDtos;
public class HotelDto
{
    public long HotelId { get; set; }
    public string HotelName { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public int TotalRooms { get; set; }
}
