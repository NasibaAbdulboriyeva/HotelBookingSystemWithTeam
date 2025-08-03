using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.PaymentDtos
{
    public class PaymentUpdateDto
    {
        public long PaymentId { get; set; }              // qaysi paymentni update qilish kerak
        public PaymentStatus Status { get; set; }        // to‘lov holatini o‘zgartirish (admin/tizim)
        public PaymentMethod PaymentMethod { get; set; }
    }
}
