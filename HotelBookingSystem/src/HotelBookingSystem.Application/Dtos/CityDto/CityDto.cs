using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.CityDto
{
    public class CityDto
    {
        public long CityId { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public string CountryName { get; set; }    // optional — mapping bilan qo‘shiladi
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
