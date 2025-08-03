using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoomPhotoDto;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.RoomPhotoService;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Infrastructure.Services.RoomPhotoServices
{
    public class RoomPhotoService : IRoomPhotoService
    {
        private readonly IRoomPhotoRepository _roomPhotoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateRoomPhotoDto> _createRoomPhotoValidator;

        public RoomPhotoService(
            IRoomPhotoRepository roomPhotoRepository,
            IMapper mapper,
            IValidator<CreateRoomPhotoDto> createRoomPhotoValidator)
        {
            _roomPhotoRepository = roomPhotoRepository;
            _mapper = mapper;
            _createRoomPhotoValidator = createRoomPhotoValidator;
        }

        public async Task<long> CreateAsync(CreateRoomPhotoDto createRoomPhotoDto)
        {
            ArgumentNullException.ThrowIfNull(createRoomPhotoDto);

            var result = await _createRoomPhotoValidator.ValidateAsync(createRoomPhotoDto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var photo = _mapper.Map<RoomPhoto>(createRoomPhotoDto);

            await _roomPhotoRepository.InsertAsync(photo);
            await _roomPhotoRepository.SaveChangesAsync();

            return photo.RoomPhotoId;
        }

        public async Task UpdateAsync(UpdateRoomPhotoDto roomPhotoUpdateDto)
        {
            ArgumentNullException.ThrowIfNull(roomPhotoUpdateDto);

            var existing = await _roomPhotoRepository.SelectByIdAsync(roomPhotoUpdateDto.RoomPhotoId);
            if (existing == null)
                throw new EntityNotFoundException("Room photo not found.");

            _mapper.Map(roomPhotoUpdateDto, existing);

            await _roomPhotoRepository.UpdateAsync(existing);
            await _roomPhotoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long roomPhotoId)
        {
            var existing = await _roomPhotoRepository.SelectByIdAsync(roomPhotoId);
            if (existing == null)
                throw new EntityNotFoundException("Room photo not found.");

            await _roomPhotoRepository.RemoveAsync(roomPhotoId);
            await _roomPhotoRepository.SaveChangesAsync();
        }

        public async Task<RoomPhotoDto> GetByIdAsync(long roomPhotoId)
        {
            var photo = await _roomPhotoRepository.SelectByIdAsync(roomPhotoId);
            if (photo == null)
                throw new EntityNotFoundException("Room photo not found.");

            return _mapper.Map<RoomPhotoDto>(photo);
        }

        public async Task<ICollection<RoomPhotoDto>> GetAllAsync()
        {
            var photos = await _roomPhotoRepository.SelectAllAsync();
            return photos.Select(_mapper.Map<RoomPhotoDto>).ToList();
        }

        public async Task<ICollection<RoomPhotoDto>> GetByRoomIdAsync(long roomId)
        {
            var photos = await _roomPhotoRepository.SelectByRoomIdAsync(roomId);
            return photos.Select(_mapper.Map<RoomPhotoDto>).ToList();
        }
    }
}
