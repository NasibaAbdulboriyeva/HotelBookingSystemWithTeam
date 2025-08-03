using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoomDtos
{
    public class RoomUpdateDto
    {
        public long RoomId { get; set; }         // qaysi xonani yangilayapmiz
        public int RoomNumber { get; set; }      // xona raqami
        public string RoomType { get; set; }     // xona turi (Single, Deluxe, Family)
        public decimal Price { get; set; }       // narxi
        public bool IsAvailable { get; set; }    // mavjud yoki yo‘q
        public bool IsDeleted { get; set; }
    }
}
