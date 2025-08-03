using HotelBookingSystem.Application.Dtos.CityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.CityService
{
    public interface ICityService
    {
        Task<long> CreateAsync(CreateCityDto createCityDto);
        Task UpdateAsync(CityUpdateDto updateCityDto);
        Task DeleteAsync(long cityId);

        Task<CityDto> GetByIdAsync(long cityId);
        Task<ICollection<CityDto>> GetAllAsync();
        Task<ICollection<CityDto>> GetByCountryIdAsync(long countryId);
    }
}
