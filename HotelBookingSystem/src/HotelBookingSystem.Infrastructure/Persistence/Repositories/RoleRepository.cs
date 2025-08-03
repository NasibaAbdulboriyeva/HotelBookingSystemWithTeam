using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;
public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        return role.RoleId;
    }

    public async Task RemoveAsync(long roleId)
    {
        var role = await SelectByIdAsync(roleId);
        _context.Roles.Remove(role);
    }

    public async Task<Role> SelectByIdAsync(long roleId)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(r => r.RoleId == roleId);
        if (role == null)
        {
            throw new KeyNotFoundException($"Role with ID {roleId} not found.");
        }
        return role;
    }

    public async Task<Role> SelectByNameAsync(string roleName)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(r => r.RoleName == roleName);
        if (role == null)
        {
            throw new KeyNotFoundException($"Role with name '{roleName}' not found.");
        }
        return role;
    }

    public async Task UpdateAsync(Role role)
    {
        _context.Roles.Update(role);
    }
    public async Task<ICollection<Role>> SelectAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
