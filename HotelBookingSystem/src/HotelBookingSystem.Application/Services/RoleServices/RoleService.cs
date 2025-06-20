using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoleDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;


namespace HotelBookingSystem.Application.Services.RoleServices
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateRoleDto> _createRoleValidator;

        public RoleService(IRoleRepository roleRepository, IMapper mapper, IValidator<CreateRoleDto> createRoleValidator)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _createRoleValidator = createRoleValidator;
        }

        public async Task<long> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            ArgumentNullException.ThrowIfNull(createRoleDto);

            var validationResult = await _createRoleValidator.ValidateAsync(createRoleDto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }

            var existingRole = await _roleRepository.SelectByNameAsync(createRoleDto.RoleName);
            if (existingRole != null)
            {
                throw new InvalidOperationException("Role with this name already exists.");
            }

            var roleEntity = _mapper.Map<Role>(createRoleDto);
            return await _roleRepository.InsertAsync(roleEntity);
        }

        public async Task DeleteRoleAsync(long roleId)
        {
            var role = await _roleRepository.SelectByIdAsync(roleId);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

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
            {
                throw new KeyNotFoundException("Role not found.");
            }

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetRoleByNameAsync(string roleName)
        {
            var role = await _roleRepository.SelectByNameAsync(roleName);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            return _mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRoleAsync(RoleDto roleDto)
        {
            if (string.IsNullOrWhiteSpace(roleDto.RoleName))
            {
                throw new ArgumentException("Role name cannot be empty.");
            }

            var role = await _roleRepository.SelectByIdAsync(roleDto.RoleId);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            await _roleRepository.UpdateAsync(role);
        }
    }
}
