using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoomTypeDto
{
    public class RoomTypeUpdateDto
    {
        public long RoomTypeId { get; set; }              // Qaysi RoomType’ni o‘zgartirish
        public string Type { get; set; }
        public string? Description { get; set; }
    }
}
