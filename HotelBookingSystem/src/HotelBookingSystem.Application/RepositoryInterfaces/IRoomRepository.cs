using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IRoomRepository
{
    Task<Room> SelectByIdAsync(long id);
    Task<ICollection<Room>> SelectByHotelIdAsync(long hotelId);
    Task<ICollection<Room>> SelectAvailableRoomsAsync(DateTime startDate, DateTime endDate);
    Task<ICollection<Room>> SelectAllAsync();
    Task<Room> SelectByNumberAsync(int roomNumber);
    Task<long> InsertAsync(Room room);
    Task UpdateAvailabilityAsync(long roomId, bool isAvailable);
    Task UpdateAsync(Room room);
}

