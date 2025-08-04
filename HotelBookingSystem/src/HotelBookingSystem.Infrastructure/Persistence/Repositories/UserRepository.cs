using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return user.UserId;
    }

    public async Task<ICollection<User>> SelectAllUsersAsync(int skip, int take)
    {
        return await _context.Users
             .Skip(skip)
             .Take(take)
             .ToListAsync();
    }

    public async Task<User> SelectByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> SelectByIdAsync(long id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        return user;
    }

    public async Task<User> SelectUserByUserNameAsync(string userName)
    {
        return await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.FirstName == userName);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
    }
    public async Task<ICollection<User>> SelectAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task RemoveAsync(long userId)
    {
        var user = await SelectByIdAsync(userId);
        _context.Users.Remove(user);
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}