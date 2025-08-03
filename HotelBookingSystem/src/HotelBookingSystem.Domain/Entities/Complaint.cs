using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Domain.Entities;

public class Complaint
{
    public long ComplaintId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public ComplaintStatus Status { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
    public long BookingId { get; set; }
    public Booking Booking { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }


}
