using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.ReviewDtos
{
    public class ReviewUpdateDto
    {
        public long ReviewId { get; set; }   // tahrir qilinayotgan review ID’si
        public int Rating { get; set; }      // baho: 1–5
        public string Comment { get; set; }
    }
}
