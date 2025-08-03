using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.HotelDtos
{
    public class HotelUpdateDto
    {
        public long HotelId { get; set; }          // update qilish uchun kerak
        public string HotelName { get; set; }      // nomi o‘zgarishi mumkin
        public string Location { get; set; }       // manzil o‘zgarishi mumkin
        public string PhoneNumber { get; set; }    // telefon o‘zgarishi mumkin
        public string Description { get; set; }    // tavsif
        public int TotalRooms { get; set; }        // xonalar soni
        public int StarRating { get; set; }        // yulduzlar soni
        public long CityId { get; set; }
    }
}
