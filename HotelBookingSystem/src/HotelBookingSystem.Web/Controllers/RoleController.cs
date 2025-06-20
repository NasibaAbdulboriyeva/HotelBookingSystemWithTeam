using HotelBookingSystem.Application.Dtos.RoleDtos;
using HotelBookingSystem.Application.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService RoleService;

        public RoleController(IRoleService roleService)
        {
            RoleService = roleService;
        }

        [HttpPost("create")]
        public Task<long> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            return RoleService.CreateRoleAsync(createRoleDto);
        }

        [HttpGet("getAll")]
        public Task<ICollection<RoleDto>> GetAllRolesAsync()
        {
            return RoleService.GetAllRolesAsync();
        }

        [HttpGet("getById")]
        public Task<RoleDto> GetRoleByIdAsync(long roleId)
        {
            return RoleService.GetRoleByIdAsync(roleId);
        }

        [HttpGet("getByName")]
        public Task<RoleDto> GetRoleByNameAsync(string roleName)
        {
            return RoleService.GetRoleByNameAsync(roleName);
        }

        [HttpPut("update")]
        public async Task UpdateRoleAsync(RoleDto roleDto)
        {
            await RoleService.UpdateRoleAsync(roleDto);
        }

        [HttpDelete("delete")]
        public Task DeleteRoleAsync(long roleId)
        {
            return RoleService.DeleteRoleAsync(roleId);
        }
    }
}
