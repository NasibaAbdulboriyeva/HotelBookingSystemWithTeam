using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.CityDto
{
    public class CreateCityDto
    {
        public string Name { get; set; }        // "Tashkent"
        public long CountryId { get; set; }     // qaysi davlatga tegishli
        public bool IsActive { get; set; }
    }
}
