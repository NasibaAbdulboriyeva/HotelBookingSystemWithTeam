using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IHotelRepository
{
    Task<Hotel> SelectByIdAsync(long id);
    Task<ICollection<Hotel>> SelectAllAsync();
    Task<long> InsertAsync(Hotel hotel);
    Task<ICollection<Hotel>> SelectByLocationAsync(string location);
    Task UpdateAsync(Hotel hotel);
    Task RemoveAsync(long id);
}

