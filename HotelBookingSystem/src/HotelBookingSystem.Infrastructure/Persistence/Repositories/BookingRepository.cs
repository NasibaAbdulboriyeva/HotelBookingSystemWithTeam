﻿
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsertAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            return booking.BookingId;
        }

        public async Task RemoveAsync(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);

            }
        }

        public async Task<ICollection<Booking>> SelectActiveBookingsByRoomIdAsync(long roomId)
        {
            return await _context.Bookings
                            .Where(b => b.BookingId == roomId && b.IsActive)
                            .ToListAsync();
        }

        public async Task<ICollection<Booking>> SelectActiveBookingsByUserIdAsync(long userId)
        {
            return await _context.Bookings
                            .Where(b => b.UserId == userId && b.IsActive)
                            .ToListAsync();
        }

        public async Task<ICollection<Booking>> SelectAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> SelectByIdAsync(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                throw new KeyNotFoundException($"Booking with Id {id} not found.");
            return booking;
        }

        public async Task<ICollection<Booking>> SelectByStatusAsync(BookingStatus status)
        {
            return await _context.Bookings
                            .Where(b => b.Status == status)
                            .ToListAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
