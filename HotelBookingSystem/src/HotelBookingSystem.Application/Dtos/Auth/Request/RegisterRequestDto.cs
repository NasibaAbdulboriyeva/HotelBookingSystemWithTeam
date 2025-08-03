

namespace HootelBooking.Application.Dtos.Auth.Request
{
    public class RegisterRequestDto
    { 
        public string UserName {  get; set; }
        public string Email {  get; set; }

        public string Password { get; set; }    

        public string Country { get; set; } 

        public string State {  get; set; }  


    }
}
