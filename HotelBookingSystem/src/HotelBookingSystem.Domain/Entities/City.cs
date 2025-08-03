using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities
{
    public class City
    {
        public long CityId { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }

}
