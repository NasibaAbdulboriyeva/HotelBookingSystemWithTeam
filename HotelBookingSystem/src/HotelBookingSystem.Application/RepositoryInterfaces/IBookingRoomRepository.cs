using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IBookingRoomRepository
{
    Task<ICollection<BookingRoom>> SelectByRoomIdAsync(long roomId);
    Task<ICollection<BookingRoom>> SelectByBookingIdAsync(long bookingId);
    Task<BookingRoom> SelectByIdsAsync(long bookingId, long roomId);
    Task<ICollection<BookingRoom>> SelectAllAsync();
    Task<long> InsertAsync(BookingRoom bookingRoom);
    Task UpdateAsync(BookingRoom bookingRoom);
    Task RemoveAsync(BookingRoom bookingRoom);
}

