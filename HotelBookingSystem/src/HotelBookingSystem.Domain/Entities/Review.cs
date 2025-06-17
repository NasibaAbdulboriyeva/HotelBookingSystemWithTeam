namespace HotelBookingSystem.Domain.Entities;

public class Review
{
    public long ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsVisible { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
