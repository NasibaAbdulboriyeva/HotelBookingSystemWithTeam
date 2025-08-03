using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoomTypeDto
{
    public class CreateRoomTypeDto
    {
        public string Type { get; set; }                  // Masalan: "Single", "Double"
        public string? Description { get; set; }
    }
}
