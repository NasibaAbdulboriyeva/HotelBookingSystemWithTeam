using AutoMapper;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<long> CreateRoomAsync(CreateRoomDto newRoom)
        {
            ArgumentNullException.ThrowIfNull(newRoom);

            var roomEntity = _mapper.Map<Room>(newRoom);
            return await _roomRepository.InsertAsync(roomEntity);
        }

        public async Task DeleteRoomAsync(long roomId)
        {
            var existingRoom = await _roomRepository.SelectByIdAsync(roomId);
            if (existingRoom == null)
            {
                throw new InvalidOperationException("Room not found.");
            }

            existingRoom.IsDeleted = true;
            existingRoom.IsAvailable = false;
            await _roomRepository.UpdateAsync(existingRoom);
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
            {
                throw new InvalidOperationException("Room not found.");
            }

            return _mapper.Map<RoomDto>(room);
        }



        public async Task UpdateRoomAsync(RoomDto roomDto)
        {
            if (roomDto == null)
            {
                throw new ArgumentNullException(nameof(roomDto));
            }

            var existingRoom = await _roomRepository.SelectByIdAsync(roomDto.RoomId);
            if (existingRoom == null || existingRoom.IsDeleted)
            {
                throw new InvalidOperationException("Room not found.");
            }

            _mapper.Map(roomDto, existingRoom);

            await _roomRepository.UpdateAsync(existingRoom);
        }

    }
}
