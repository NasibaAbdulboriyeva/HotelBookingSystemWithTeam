﻿using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;
public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _context;
    public UserRoleRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Role>> SelectRolesByUserIdAsync(long userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.Role)
            .ToListAsync();
    }
    public async Task<long> InsertUserRoleAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        return userRole.RoleId;
    }
    public async Task RemoveUserRoleAsync(long userId, long roleId)
    {
        var userRole = await _context.UserRoles
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

        if (userRole != null)
        {
            _context.UserRoles.Remove(userRole);
        }
    }
    public async Task<ICollection<UserRole>> SelectAllAsync()
    {
        return await _context.UserRoles.ToListAsync();
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

