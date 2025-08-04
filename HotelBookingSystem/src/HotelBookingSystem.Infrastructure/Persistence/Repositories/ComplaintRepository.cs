﻿using HotelBookingSystem.Application.RepositoryInterfaces;
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
       await  _context.Complaints.AddAsync(complaint);
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

    public async Task UpdateAsync(Complaint complaint)
    {

        _context.Update(complaint);
    }
    public async Task<ICollection<Complaint>> SelectAllAsync()
    {
        return await _context.Complaints.ToListAsync();
    }

    public async Task RemoveAsync(long complaintId)
    {
        var complaint = await _context.Complaints.FirstOrDefaultAsync(c => c.ComplaintId == complaintId);

        _context.Complaints.Remove(complaint);
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
