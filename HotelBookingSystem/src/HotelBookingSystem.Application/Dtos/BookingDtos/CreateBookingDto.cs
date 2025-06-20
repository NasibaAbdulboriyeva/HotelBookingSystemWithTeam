using HotelBookingSystem.Application.Dtos.PaymentDtos;

namespace HotelBookingSystem.Application.Dtos.BookingDtos;
public class CreateBookingDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CreatePaymentDto Payment { get; set; }
    public long UserId { get; set; }
    public long HotelId { get; set; }
    public long RoomId { get; set; }
}
