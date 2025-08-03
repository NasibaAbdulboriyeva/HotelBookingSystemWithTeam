using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;
public class HotelRepository : IHotelRepository
{
    private readonly AppDbContext _context;

    public HotelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
        return hotel.HotelId;
    }

    public async Task RemoveAsync(long id)
    {
        var hotel = await SelectByIdAsync(id);
        _context.Hotels.Remove(hotel);
    }

    public async Task<ICollection<Hotel>> SelectAllAsync()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel> SelectByIdAsync(long id)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);
        if (hotel == null)
        {
            throw new KeyNotFoundException($"Hotel with ID {id} not found.");
        }
        return hotel;
    }

    public async Task<ICollection<Hotel>> SelectByLocationAsync(string location)
    {
        return await _context.Hotels
           .Where(h => h.Location.ToLower().Contains(location.ToLower()))
           .ToListAsync();
    }

    public async Task UpdateAsync(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
