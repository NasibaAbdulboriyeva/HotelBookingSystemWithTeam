namespace HotelBookingSystem.Application.Dtos.BookingDtos;
public class BookingDto
{
    public long BookingId { get; set; }
    public long UserId { get; set; }
    public long RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Status { get; set; }
}



