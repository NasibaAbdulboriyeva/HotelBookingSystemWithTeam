using AutoMapper;
using HotelBookingSystem.Application.Dtos.RoleDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.RoleServices
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<long> CreateRoleAsync(Role role)
        {
            if (string.IsNullOrWhiteSpace(role.RoleName))
                throw new ArgumentException("Role name cannot be empty.");

            var existingRole = await _roleRepository.SelectByNameAsync(role.RoleName);
            if (existingRole != null)
                throw new InvalidOperationException("Role with this name already exists.");

            return await _roleRepository.InsertAsync(role);
        }

        public async Task DeleteRoleAsync(long roleId)
        {
            var role = await _roleRepository.SelectByIdAsync(roleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found.");

            await _roleRepository.RemoveAsync(roleId);
        }

        public async Task<ICollection<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.SelectAllAsync();
            return roles.Select(r => _mapper.Map<RoleDto>(r)).ToList();
        }

        public async Task<RoleDto> GetRoleByIdAsync(long roleId)
        {
            var role = await _roleRepository.SelectByIdAsync(roleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found.");

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetRoleByNameAsync(string roleName)
        {
            var role = await _roleRepository.SelectByNameAsync(roleName);
            if (role == null)
                throw new KeyNotFoundException("Role not found.");

            return _mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRoleAsync(Role roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId.RoleName))
                throw new ArgumentException("Role name cannot be empty.");

            var role = await _roleRepository.SelectByIdAsync(roleId.RoleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found.");

            await _roleRepository.UpdateAsync(role);
        }
    }
}
