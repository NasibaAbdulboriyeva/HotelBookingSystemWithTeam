using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;


namespace HotelBookingSystem.Application.Services.UserServices
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserDto> _createUserValidator;

        public UserService(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserDto> createUserValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _createUserValidator = createUserValidator;
        }

        public async Task<long> CreateUserAsync(CreateUserDto createUserDto)
        {
            ArgumentNullException.ThrowIfNull(createUserDto);

            var validationResult = await _createUserValidator.ValidateAsync(createUserDto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Validation failed: {errors}");
            }

            var existingUser = await _userRepository.SelectByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            var userEntity = _mapper.Map<User>(createUserDto);
            return await _userRepository.InsertAsync(userEntity);
        }

        public async Task DeleteUserAsync(long userId)
        {
            var user = await _userRepository.SelectByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            await _userRepository.RemoveAsync(userId);
        }

        public async Task<ICollection<UserDto>> GetAllUsersAsync(int skip, int take)
        {
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException("Skip value cannot be negative.");

            }
            if (take <= 0 || take > 100)
            {
                throw new ArgumentOutOfRangeException("Take must be between 1 and 100.");
            }
            var users = await _userRepository.SelectAllUsersAsync(skip, take);
            return users.Select(u => _mapper.Map<UserDto>(u)).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(long userId)
        {
            var user = await _userRepository.SelectByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto);

            var validationResult = await _createUserValidator.ValidateAsync(_mapper.Map<CreateUserDto>(userDto));
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Validation failed");
            }

            var existingUser = await _userRepository.SelectByIdAsync(userDto.UserId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            _mapper.Map(userDto, existingUser);
            await _userRepository.UpdateAsync(existingUser);
        }
    }
}
