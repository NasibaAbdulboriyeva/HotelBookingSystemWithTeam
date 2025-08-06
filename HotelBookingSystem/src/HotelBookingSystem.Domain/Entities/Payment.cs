using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public decimal PaidAmount { get; set; }
    public PaymentStatus Status { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime PaidAt { get; set; }
    public long BookingId { get; set; }
    public Booking Booking { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

}
