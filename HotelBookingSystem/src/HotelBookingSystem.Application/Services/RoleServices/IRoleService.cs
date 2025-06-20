using HotelBookingSystem.Application.Dtos.RoleDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.RoleServices
{
    public interface IRoleService
    {
        Task<long> CreateRoleAsync(Role role);
        Task<RoleDto> GetRoleByIdAsync(long roleId);
        Task<RoleDto> GetRoleByNameAsync(string roleName);
        Task<ICollection<RoleDto>> GetAllRolesAsync();
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(long roleId);
    }
}