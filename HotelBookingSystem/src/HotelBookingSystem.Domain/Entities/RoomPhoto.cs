using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities
{
    public class RoomPhoto
    {
        public long RoomPhotoId { get; set; }             // Primary key for the photo
        public long RoomId { get; set; }               // Foreign key to the Room
        public string PhotoName { get; set; }         // File path or URL to the photo

        public Room Room { get; set; }
    }
}
