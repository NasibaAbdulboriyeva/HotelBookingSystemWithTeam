using HotelBookingSystem.Application;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AppDbContext AppDbContext;

    public RefreshTokenRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }
    public async Task InsertRefreshTokenAsync(RefreshToken refreshToken)
    {
        await AppDbContext.RefreshTokens.AddAsync(refreshToken);
    }
    public async Task RemoveRefreshTokenAsync(string token)
    {
        var rToken = await AppDbContext.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == token);

        if (rToken == null)
        {
            throw new KeyNotFoundException($"Refresh token {token} not found.");
        }

        AppDbContext.RefreshTokens.Remove(rToken);
    }
    public async Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId)
    {
        var token = await AppDbContext.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.UserId == userId);

        if (token == null)
        {
            throw new KeyNotFoundException($"Refresh token {refreshToken} for user ID {userId} not found.");
        }

        return token;
    }

    public async Task UpdateRefreshTokenAsync(RefreshToken refreshToken)
    {
        var existingToken = await AppDbContext.RefreshTokens
           .FirstOrDefaultAsync(t => t.Token == refreshToken.Token && t.UserId == refreshToken.UserId);

        if (existingToken == null)
        {
            throw new EntityNotFoundException($"Refresh token {refreshToken.Token} not found for user {refreshToken.UserId}");
        }

        existingToken.IsRevoked = refreshToken.IsRevoked;

        existingToken.ExpirationDate = refreshToken.ExpirationDate;

        AppDbContext.RefreshTokens.Update(existingToken);
    }
    public async Task<int> SaveChangesAsync()
    {
        return await AppDbContext.SaveChangesAsync();
    }
}
