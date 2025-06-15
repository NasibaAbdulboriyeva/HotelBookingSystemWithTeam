namespace HotelBookingSystem.Domain.Entities;

public class Booking
{
    public long BookingId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public BookingStatus Status { get; set; }
    public bool IsActive { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
  

}
