using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.CountryDto
{
    public class CountryDto
    {
        public long CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? PhoneCode { get; set; }
        public string? Currency { get; set; }
        public bool IsActive { get; set; }
    }
}
