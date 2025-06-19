using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IUserRoleRepository
{
    Task<ICollection<Role>> SelectRolesByUserIdAsync(long userId);
    Task<long> InsertUserRoleAsync(UserRole userRole);
    Task RemoveUserRoleAsync(long userId, long roleId);
}

