using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IRoleRepository
{
    Task<long> InsertAsync(Role role);
    Task<Role> SelectByIdAsync(long roleId);
    Task<Role> SelectByNameAsync(string roleName);
    Task UpdateAsync(Role role);
    Task RemoveAsync(long roleId);
}
