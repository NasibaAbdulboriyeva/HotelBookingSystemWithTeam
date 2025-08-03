using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoomPhotoDto
{
    public class RoomPhotoDto
    {
        public long RoomPhotoId { get; set; }
        public int RoomId { get; set; }
        public string PhotoName { get; set; }
    }
}
