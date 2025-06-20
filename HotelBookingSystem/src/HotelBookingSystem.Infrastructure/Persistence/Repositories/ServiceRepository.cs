using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Service> SelectByIdAsync(long id)
    {
        var service = await _context.Services
            .FirstOrDefaultAsync(s => s.ServiceId == id);

        if (service == null)
        {
            throw new KeyNotFoundException($"Service with ID {id} not found.");
        }

        return service;
    }
    public async Task<ICollection<Service>> SelectAllAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task<ICollection<Service>> SelectByHotelIdAsync(long hotelId)
    {
        return await _context.Services
            .Where(s => s.HotelId == hotelId)
            .ToListAsync();
    }

    public async Task<long> InsertAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return service.ServiceId;
    }

    public async Task UpdateAsync(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(long serviceId)
    {
        var service = await SelectByIdAsync(serviceId);
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
    }
}
