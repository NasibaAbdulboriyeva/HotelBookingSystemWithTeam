
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Booking>> GetByStatusAsync(BookingStatus status)
        {
            return await _context.Bookings
                .Where(b => b.Status == status)
                .ToListAsync();
        }

        public async Task InsertAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> SelectActiveBookingsByRoomIdAsync(long roomId)
        {
            return await _context.Bookings
                            .Where(b => b.BookingId == roomId && b.IsActive)
                            .ToListAsync();
        }

        public async Task<List<Booking>> SelectActiveBookingsByUserIdAsync(long userId)
        {
            return await _context.Bookings
                            .Where(b => b.UserId == userId && b.IsActive)
                            .ToListAsync();
        }

        public async Task<List<Booking>> SelectAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> SelectByIdAsync(long id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
