using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application;

public interface IRefreshTokenRepository
{
    Task InsertRefreshTokenAsync(RefreshToken refreshToken);
    Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId);
    Task RemoveRefreshTokenAsync(string token);
    Task UpdateRefreshTokenAsync(RefreshToken refreshToken);
    Task<int> SaveChangesAsync();
}
