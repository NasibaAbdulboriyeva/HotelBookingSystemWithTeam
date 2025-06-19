using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IServiceRepository
{
    Task<Service> SelectByIdAsync(long id);
    Task<ICollection<Service>> SelectByHotelIdAsync(long hotelId);
    Task<long> InsertAsync(Service service);
    Task UpdateAsync(Service service);
}

