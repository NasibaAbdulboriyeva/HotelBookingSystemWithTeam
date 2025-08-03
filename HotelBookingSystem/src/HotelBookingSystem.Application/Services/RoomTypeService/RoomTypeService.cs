using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoomTypeDto;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.RoomTypeService;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.RoomTypeServices;

public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateRoomTypeDto> _createValidator;

    public RoomTypeService(
        IRoomTypeRepository roomTypeRepository,
        IMapper mapper,
        IValidator<CreateRoomTypeDto> createValidator)
    {
        _roomTypeRepository = roomTypeRepository;
        _mapper = mapper;
        _createValidator = createValidator;
    }

    public async Task<long> CreateAsync(CreateRoomTypeDto createRoomTypeDto)
    {
        ArgumentNullException.ThrowIfNull(createRoomTypeDto);

        var validation = await _createValidator.ValidateAsync(createRoomTypeDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var existing = await _roomTypeRepository.SelectByNameAsync(createRoomTypeDto.Type);
        if (existing is not null)
            throw new InvalidOperationException("Room type already exists.");

        var entity = _mapper.Map<RoomType>(createRoomTypeDto);
        await _roomTypeRepository.InsertAsync(entity);
        await _roomTypeRepository.SaveChangesAsync();

        return entity.RoomTypeId;
    }

    public async Task UpdateAsync(RoomTypeUpdateDto updateDto)
    {
        ArgumentNullException.ThrowIfNull(updateDto);


        var existing = await _roomTypeRepository.SelectByIdAsync(updateDto.RoomTypeId);
        if (existing is null)
            throw new KeyNotFoundException("Room type not found.");

        _mapper.Map(updateDto, existing);
        await _roomTypeRepository.UpdateAsync(existing);
        await _roomTypeRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(long roomTypeId)
    {
        var existing = await _roomTypeRepository.SelectByIdAsync(roomTypeId);
        if (existing is null)
            throw new KeyNotFoundException("Room type not found.");

        await _roomTypeRepository.RemoveAsync(roomTypeId);
        await _roomTypeRepository.SaveChangesAsync();
    }

    public async Task<RoomTypeDto> GetByIdAsync(long roomTypeId)
    {
        var roomType = await _roomTypeRepository.SelectByIdAsync(roomTypeId);
        if (roomType is null)
            throw new KeyNotFoundException("Room type not found.");

        return _mapper.Map<RoomTypeDto>(roomType);
    }

    public async Task<RoomTypeDto> GetByNameAsync(string name)
    {
        var roomType = await _roomTypeRepository.SelectByNameAsync(name);
        if (roomType is null)
            throw new KeyNotFoundException("Room type not found.");

        return _mapper.Map<RoomTypeDto>(roomType);
    }

    public async Task<ICollection<RoomTypeDto>> GetAllAsync()
    {
        var list = await _roomTypeRepository.SelectAllAsync();
        return list.Select(_mapper.Map<RoomTypeDto>).ToList();
    }
}
