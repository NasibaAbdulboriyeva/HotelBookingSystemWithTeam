using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.RoomServices;
using HotelBookingSystem.Domain.Entities;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateRoomDto> _createRoomDtoValidator;

    public RoomService(IRoomRepository roomRepository, IMapper mapper, IValidator<CreateRoomDto> createRoomDtoValidator)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _createRoomDtoValidator = createRoomDtoValidator;
    }

    public async Task<long> CreateRoomAsync(CreateRoomDto newRoom)
    {
        ArgumentNullException.ThrowIfNull(newRoom);

        var validationResult = await _createRoomDtoValidator.ValidateAsync(newRoom);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var roomEntity = _mapper.Map<Room>(newRoom);

        await _roomRepository.InsertAsync(roomEntity);
        await _roomRepository.SaveChangesAsync(); // <-- qo‘shildi

        return roomEntity.RoomId;
    }

    public async Task DeleteRoomAsync(long roomId)
    {
        var existingRoom = await _roomRepository.SelectByIdAsync(roomId);
        if (existingRoom == null)
            throw new InvalidOperationException("Room not found.");

        existingRoom.IsDeleted = true;
        existingRoom.IsAvailable = false;

        await _roomRepository.UpdateAsync(existingRoom);
        await _roomRepository.SaveChangesAsync(); // <-- qo‘shildi
    }

    public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
    {
        var rooms = await _roomRepository.SelectAllAsync();
        var filtered = rooms.Where(r => !r.IsDeleted);
        return filtered.Select(room => _mapper.Map<RoomDto>(room)).ToList();
    }

    public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync()
    {
        var rooms = await _roomRepository.SelectAllAsync();
        var filtered = rooms.Where(r => r.IsAvailable && !r.IsDeleted);
        return filtered.Select(room => _mapper.Map<RoomDto>(room)).ToList();
    }

    public async Task<RoomDto> GetRoomByIdAsync(long roomId)
    {
        var room = await _roomRepository.SelectByIdAsync(roomId);
        if (room == null || room.IsDeleted)
            throw new InvalidOperationException("Room not found.");

        return _mapper.Map<RoomDto>(room);
    }

    public async Task UpdateRoomAsync(RoomUpdateDto roomDto)
    {
        ArgumentNullException.ThrowIfNull(roomDto);

        var existingRoom = await _roomRepository.SelectByIdAsync(roomDto.RoomId);
        if (existingRoom == null || existingRoom.IsDeleted)
            throw new InvalidOperationException("Room not found.");

        _mapper.Map(roomDto, existingRoom);

        await _roomRepository.UpdateAsync(existingRoom);
        await _roomRepository.SaveChangesAsync(); // <-- qo‘shildi
    }
}
