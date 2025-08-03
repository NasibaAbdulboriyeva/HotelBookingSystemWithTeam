using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.CountryDto
{
    public class CountryCreateDto
    {
        public string Name { get; set; }             // "Uzbekistan"
        public string Code { get; set; }             // "UZ"
        public string? PhoneCode { get; set; }       // "+998"
        public string? Currency { get; set; }        // "UZS"
        public bool IsActive { get; set; }
    }
}
