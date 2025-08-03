using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.ComplaintDtos
{
    public class ComplaintUpdateDto
    {
        public long ComplaintId { get; set; }       // qaysi complaint'ni yangilash kerak
        public string Message { get; set; }         // foydalanuvchi xabarni o‘zgartiradi
        public ComplaintStatus Status { get; set; }
    }
}
