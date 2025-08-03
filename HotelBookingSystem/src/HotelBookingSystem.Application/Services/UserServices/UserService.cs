using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.UserServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserDto> _createUserValidator;

    public UserService(
        IUserRepository userRepository,
        IMapper mapper,
        IValidator<CreateUserDto> createUserValidator)
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
            throw new ValidationException(validationResult.Errors);

        var exists = await _userRepository.SelectByEmailAsync(createUserDto.Email);
        if (exists is not null)
            throw new InvalidOperationException("User with this email already exists.");

        var userEntity = _mapper.Map<User>(createUserDto);

        await _userRepository.InsertAsync(userEntity);
        await _userRepository.SaveChangesAsync();

        return userEntity.UserId;
    }

    public async Task UpdateUserAsync(UserUpdateDto userDto)
    {
        ArgumentNullException.ThrowIfNull(userDto);

        var validationResult = await _createUserValidator.ValidateAsync(
            _mapper.Map<CreateUserDto>(userDto));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userRepository.SelectByIdAsync(userDto.UserId);
        if (user is null)
            throw new KeyNotFoundException("User not found.");

        _mapper.Map(userDto, user);

        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(long userId)
    {
        var user = await _userRepository.SelectByIdAsync(userId);
        if (user is null)
            throw new KeyNotFoundException("User not found.");

        await _userRepository.RemoveAsync(userId);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<UserDto> GetUserByIdAsync(long userId)
    {
        var user = await _userRepository.SelectByIdAsync(userId);
        if (user is null)
            throw new KeyNotFoundException("User not found.");

        return _mapper.Map<UserDto>(user);
    }

    public async Task<ICollection<UserDto>> GetAllUsersAsync(int skip, int take)
    {
        if (skip < 0)
            throw new ArgumentOutOfRangeException(nameof(skip), "Skip must be non-negative.");

        if (take is <= 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(take), "Take must be between 1 and 100.");

        var users = await _userRepository.SelectAllUsersAsync(skip, take);
        return users.Select(_mapper.Map<UserDto>).ToList();
    }
}
