using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.BookingDtos
{
    public class BookingUpdateDto
    {
        public long BookingId { get; set; }           // mavjud bo‘lgan bookingni aniqlash uchun
        public DateTime StartDate { get; set; }       // foydalanuvchi o‘zgartirishi mumkin
        public DateTime EndDate { get; set; }         // foydalanuvchi o‘zgartirishi mumkin
        public BookingStatus Status { get; set; }     // admin/foydalanuvchi update qilishi mumkin
        public bool IsActive { get; set; }            // soft delete yoki aktivlik
        public long UserId { get; set; }              // kam holatda update bo‘ladi
        public List<long> RoomIds { get; set; }
    }
}
