using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.HotelService
{
    public interface IHotelService
    {
        Task<HotelDto> GetByIdAsync(long id);
        Task<ICollection<HotelDto>> GetAllAsync();
        Task<long> AddAsync(CreateHotelDto createHotelDto);
        Task<ICollection<HotelDto>> GetByLocationAsync(string location);
        Task UpdateAsync(HotelDto hotelDto);
        Task DeleteAsync(long id);
    }
}