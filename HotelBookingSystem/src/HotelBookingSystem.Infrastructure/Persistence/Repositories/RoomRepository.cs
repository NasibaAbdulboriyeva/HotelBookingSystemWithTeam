using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;
public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }  
    public async Task<long> InsertAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room.RoomId;
    }

    public async Task<ICollection<Room>> SelectAvailableRoomsAsync(DateTime startDate, DateTime endDate)
    {
        var bookedRoom = await _context.BookingRooms
        .Where(br =>
            (startDate < br.Booking.EndDate) &&
            (endDate > br.Booking.StartDate) &&
            br.Booking.Status != BookingStatus.Cancelled
        )
           .Select(br => br.RoomId)
           .ToListAsync();

        return await _context.Rooms
            .Where(r => r.IsAvailable && !bookedRoom.Contains(r.RoomId))
            .ToListAsync();
    }

    public async Task<ICollection<Room>> SelectByHotelIdAsync(long hotelId)
    {
        return await _context.Rooms
            .Where(r => r.HotelId == hotelId)
            .ToListAsync();
    }

    public async Task<Room> SelectByIdAsync(long id)
    {
        var room = await _context.Rooms
            .FirstOrDefaultAsync(r => r.RoomId == id);
        if (room == null)
        {
            throw new KeyNotFoundException($"Room with ID {id} not found.");
        }
        return room;
    }

    public async Task<Room> SelectByNumberAsync(int roomNumber)
    {
       var room = await _context.Rooms
            .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            throw new KeyNotFoundException($"Room with number {roomNumber} not found.");
        }
        return room;
    }

    public async Task UpdateAvailabilityAsync(long roomId, bool isAvailable)
    {
        var room = await SelectByIdAsync(roomId);
        room.IsAvailable = isAvailable;
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }
    public async Task<ICollection<Room>> SelectAllAsync()
    {
        return await _context.Rooms.ToListAsync();
    }
}
