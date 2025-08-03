using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }      // ismi
        public string LastName { get; set; }       // familiyasi
        public string Email { get; set; }          // email manzil
        public string PhoneNumber { get; set; }
    }
}
