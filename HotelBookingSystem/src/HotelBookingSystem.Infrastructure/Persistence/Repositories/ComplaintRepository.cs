using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;
public class ComplaintRepository : IComplaintRepository
{
    private readonly AppDbContext _context;

    public ComplaintRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Complaint complaint)
    {
        _context.Complaints.Add(complaint);
        await _context.SaveChangesAsync();
        return complaint.ComplaintId;
    }

    public async Task<ICollection<Complaint>> SelectByHotelIdAsync(long hotelId)
    {
        return await _context.Complaints
            .Where(c => c.HotelId == hotelId)
            .ToListAsync();
    }

    public async Task<Complaint> SelectByIdAsync(long id)
    {
        var complaint = await _context.Complaints
            .FirstOrDefaultAsync(c => c.ComplaintId == id);
        if (complaint == null)
        {
            throw new KeyNotFoundException($"Complaint with ID {id} not found.");
        }
        return complaint;
    }

    public async Task<ICollection<Complaint>> SelectByStatusAsync(ComplaintStatus status)
    {
        return await _context.Complaints
            .Where(c => c.Status == status)
            .ToListAsync();
    }

    public async Task<ICollection<Complaint>> SelectByUserIdAsync(long userId)
    {
        return await _context.Complaints
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task UpdateStatusAsync(long complaintId)
    {
        var complaint = await SelectByIdAsync(complaintId);

        _context.Update(complaint);
        await _context.SaveChangesAsync();
    }
    public async Task<ICollection<Complaint>> SelectAllAsync()
    {
        return await _context.Complaints.ToListAsync();
    }
}
