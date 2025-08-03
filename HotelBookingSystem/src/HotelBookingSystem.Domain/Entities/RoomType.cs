using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities
{
    public class RoomType
    {
        public long RoomTypeId { get; set; }

        public string Type { get; set; }

        public string? Description { get; set; }


        //Navigation Properties 

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}
