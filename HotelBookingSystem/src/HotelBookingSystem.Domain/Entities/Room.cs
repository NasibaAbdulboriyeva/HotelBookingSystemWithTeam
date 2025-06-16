namespace HotelBookingSystem.Domain.Entities;

public class Room
{
    public long RoomId { get; set; }
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public decimal Price { get; set; }
    public bool Availibility { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
