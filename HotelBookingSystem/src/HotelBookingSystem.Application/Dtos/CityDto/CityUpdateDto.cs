using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.CityDto
{
    public class CityUpdateDto
    {
        public long CityId { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
