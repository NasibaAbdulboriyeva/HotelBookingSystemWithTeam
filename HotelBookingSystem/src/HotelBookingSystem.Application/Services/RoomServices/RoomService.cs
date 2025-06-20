using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.RoomServices
{
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
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"The information of this room is incorrect: {errors}");
            }

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
            await _roomRepository.UpdateAvailabilityAsync(existingRoom.RoomId, false);
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

        public async Task UpdateRoomAsync(long roomId, CreateRoomDto updatedRoom)
        {
            ArgumentNullException.ThrowIfNull(updatedRoom);

            var validationResult = await _createRoomDtoValidator.ValidateAsync(updatedRoom);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"The information of this room is incorrect: {errors}");
            }

            var existingRoom = await _roomRepository.SelectByIdAsync(roomId);
            if (existingRoom == null || existingRoom.IsDeleted)
            {
                throw new InvalidOperationException("Room not found.");
            }

            _mapper.Map(updatedRoom, existingRoom); 
            await _roomRepository.UpdateAvailabilityAsync(existingRoom.RoomId,existingRoom.IsAvailable);
        }
    }
}
