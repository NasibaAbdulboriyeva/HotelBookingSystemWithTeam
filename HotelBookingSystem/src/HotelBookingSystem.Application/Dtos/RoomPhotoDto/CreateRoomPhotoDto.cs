using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoomPhotoDto
{
    public class CreateRoomPhotoDto
    {
        public int RoomId { get; set; }             // Qaysi xonaga tegishli
        public string PhotoName { get; set; }
    }
}
