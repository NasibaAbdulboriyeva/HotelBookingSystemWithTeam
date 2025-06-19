using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories
{
    interface IBookingRepository
    {
        Task<Booking> SelectByIdAsync(long id);

        Task<List<Booking>> SelectAllAsync();

        Task<List<Booking>> SelectActiveBookingsByUserIdAsync(long userId);

        Task<List<Booking>> SelectActiveBookingsByRoomIdAsync(long roomId);

        Task<List<Booking>> GetByStatusAsync(BookingStatus status);

        Task InsertAsync(Booking booking);

        Task UpdateAsync(Booking booking);

        Task DeleteAsync(long id);
    }
}
