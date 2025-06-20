using HotelBookingSystem.Application.Dtos.RoleDtos;
using HotelBookingSystem.Application.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public Task<long> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            return _roleService.CreateRoleAsync(createRoleDto);
        }

        [HttpGet("getAll")]
        public Task<ICollection<RoleDto>> GetAllRolesAsync()
        {
            return _roleService.GetAllRolesAsync();
        }

        [HttpGet("getById")]
        public Task<RoleDto> GetRoleByIdAsync(long roleId)
        {
            return _roleService.GetRoleByIdAsync(roleId);
        }

        [HttpGet("getByName")]
        public Task<RoleDto> GetRoleByNameAsync(string roleName)
        {
            return _roleService.GetRoleByNameAsync(roleName);
        }

        [HttpPut("update")]
        public Task UpdateRoleAsync(RoleDto roleDto)
        {
            return _roleService.UpdateRoleAsync(roleDto);
        }

        [HttpDelete("delete")]
        public Task DeleteRoleAsync(long roleId)
        {
            return _roleService.DeleteRoleAsync(roleId);
        }
    }
}
