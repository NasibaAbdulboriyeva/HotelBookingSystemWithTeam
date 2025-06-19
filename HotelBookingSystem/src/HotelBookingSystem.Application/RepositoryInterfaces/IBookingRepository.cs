using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IBookingRepository
{
    Task<Booking> SelectByIdAsync(long id);
    Task<ICollection<Booking>> SelectAllAsync();
    Task<ICollection<Booking>> SelectActiveBookingsByUserIdAsync(long userId);
    Task<ICollection<Booking>> SelectActiveBookingsByRoomIdAsync(long roomId);
    Task<ICollection<Booking>> SelectByStatusAsync(BookingStatus status);
    Task<long> InsertAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task RemoveAsync(long id);
}

