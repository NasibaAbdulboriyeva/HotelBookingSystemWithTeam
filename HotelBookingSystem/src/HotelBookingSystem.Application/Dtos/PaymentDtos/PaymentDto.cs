using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Dtos.PaymentDtos;
public class PaymentDto
{
    public long PaymentId { get; set; }
    public decimal PaidAmount { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime PaidAt { get; set; }
    public long? BookingId { get; set; }
}
