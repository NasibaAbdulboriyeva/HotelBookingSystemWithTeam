using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoomTypeDto
{
    public class RoomTypeDto
    {
        public long RoomTypeId { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
    }
}
