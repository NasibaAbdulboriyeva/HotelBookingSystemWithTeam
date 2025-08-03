using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities
{
    public class Country
    {
        public long CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } // "UZ"
        public string? PhoneCode { get; set; } // "+998"
        public string? Currency { get; set; } // "UZS"
        public bool IsActive { get; set; }


        public ICollection<City> Cities { get; set; } = new List<City>();
    }

}
