using HotelBookingSystem.Application.Dtos.ServiceDtos;

namespace HotelBookingSystem.Application.Services.AffairService;

public interface IAffairService
{
    Task<ServiceDto> GetByIdAsync(long id);
    Task<ICollection<ServiceDto>> GetByHotelIdAsync(long hotelId);
    Task<ICollection<ServiceDto>> GetAllAsync();
    Task<long> CreateAsync(CreateServiceDto dto);
    Task UpdateAsync(ServiceDto dto);
    Task DeleteAsync(long id);
}