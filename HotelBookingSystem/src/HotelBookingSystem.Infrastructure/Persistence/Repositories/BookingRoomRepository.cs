using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories
{
    public class BookingRoomRepository : IBookingRoomRepository
    {
        private readonly AppDbContext _context;

        public BookingRoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertAsync(BookingRoom bookingRoom)
        {
            await _context.BookingRooms.AddAsync(bookingRoom);
            await _context.SaveChangesAsync();
            return bookingRoom.RoomId;
        }

        public async Task RemoveAsync(BookingRoom bookingRoom)
        {
            if (bookingRoom == null)
            {
                throw new ArgumentNullException(nameof(bookingRoom));
            }
            _context.BookingRooms.Remove(bookingRoom);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BookingRoom>> SelectByBookingIdAsync(long bookingId)
        {
            return await _context.BookingRooms
                           .Where(br => br.BookingId == bookingId)
                           .ToListAsync();
        }

        public async Task<BookingRoom> SelectByIdsAsync(long bookingId, long roomId)
        {
            var bookingRoom = await _context.BookingRooms
                            .FirstOrDefaultAsync(br => br.BookingId == bookingId && br.RoomId == roomId);

            if (bookingRoom == null)
            {
                throw new KeyNotFoundException($"BookingRoom with BookingId {bookingId} and RoomId {roomId} not found.");
            }
            return bookingRoom;

        }

        public async Task<ICollection<BookingRoom>> SelectByRoomIdAsync(long roomId)
        {
            return await _context.BookingRooms
                            .Where(br => br.RoomId == roomId)
                            .ToListAsync();
        }

        public async Task UpdateAsync(BookingRoom bookingRoom)
        {
            _context.BookingRooms.Update(bookingRoom);
            await _context.SaveChangesAsync();
        }
    }
}
