using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HootelBooking.Application.Dtos.Auth.Request
{
    public class ChangePasswordRequestDto
    {
        public string Email { get; set; }   
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
