using HotelBookingSystem.Application.Dtos.CountryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.CountryService
{
    public interface ICountryService
    {
        Task<long> CreateAsync(CountryCreateDto createCountryDto);
        Task UpdateAsync(CountryUpdateDto updateCountryDto);
        Task DeleteAsync(long countryId);

        Task<CountryDto> GetByIdAsync(long countryId);
        Task<CountryDto> GetByCodeAsync(string code);
        Task<ICollection<CountryDto>> GetAllAsync();
    }
}
