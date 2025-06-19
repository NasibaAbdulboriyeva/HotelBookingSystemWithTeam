using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IUserRoleRepository
{
    Task<ICollection<Role>> SelectRolesByUserIdAsync(long userId);
    Task<long> InsertUserRoleAsync(UserRole userRole);
    Task<ICollection<UserRole>> SelectAllAsync();
    Task RemoveUserRoleAsync(long userId, long roleId);
}

