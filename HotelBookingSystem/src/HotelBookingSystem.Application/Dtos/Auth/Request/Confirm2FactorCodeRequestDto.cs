namespace HootelBooking.Application.Dtos.Auth.Request
{
    public class Confirm2FactorCodeRequestDto
    {
        public string Email { get; set; }

        public string TwoFactorCode { get; set; }
    }
}
