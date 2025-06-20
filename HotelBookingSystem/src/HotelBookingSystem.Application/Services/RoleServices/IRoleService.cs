using HotelBookingSystem.Application.Dtos.RoleDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.RoleServices
{
    public interface IRoleService
    {
        Task<long> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<RoleDto> GetRoleByIdAsync(long roleId);
        Task<RoleDto> GetRoleByNameAsync(string roleName);
        Task<ICollection<RoleDto>> GetAllRolesAsync();
        Task UpdateRoleAsync(RoleDto role);
        Task DeleteRoleAsync(long roleId);
    }
}