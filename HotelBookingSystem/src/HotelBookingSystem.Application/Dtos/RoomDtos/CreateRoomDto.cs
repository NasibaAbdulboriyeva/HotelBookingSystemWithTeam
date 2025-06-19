namespace HotelBookingSystem.Application.Dtos.RoomDtos;
public class CreateRoomDto
{
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

    public long HotelId { get; set; }
}
