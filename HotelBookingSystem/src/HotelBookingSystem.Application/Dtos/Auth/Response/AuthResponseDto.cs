using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HootelBooking.Application.Dtos.Auth.Response
{
    public class AuthResponseDto
    {
        public int Id { get; set; } 

        public string UserName { get; set; }    
        
        public string Email { get; set; }

        public string Country { get; set; } 

        public string State { get; set; }   

        public bool IsActive { get; set; }  

        public string Photo {  get; set; }    


    }
}
