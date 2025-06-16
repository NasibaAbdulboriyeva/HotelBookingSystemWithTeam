namespace HotelBookingSystem.Domain.Entities;
public class BookingRoom
{
    public long BookingId { get; set; }
    public Booking Booking { get; set; }

    public long RoomId { get; set; }
    public Room Room { get; set; }
}
