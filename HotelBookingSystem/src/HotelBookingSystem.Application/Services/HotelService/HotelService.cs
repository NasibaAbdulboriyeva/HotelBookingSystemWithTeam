using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Services.HotelService
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateHotelDto> _createHotelDtoValidator;

        public HotelService(
            IHotelRepository hotelRepository,
            IMapper mapper,
            IValidator<CreateHotelDto> createHotelDtoValidator)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _createHotelDtoValidator = createHotelDtoValidator;
        }

        public async Task<long> AddAsync(CreateHotelDto createHotelDto)
        {
            ArgumentNullException.ThrowIfNull(createHotelDto);

            var validationResult = await _createHotelDtoValidator.ValidateAsync(createHotelDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var hotel = _mapper.Map<Hotel>(createHotelDto);

            await _hotelRepository.InsertAsync(hotel);
            await _hotelRepository.SaveChangesAsync();

            return hotel.HotelId;
        }

        public async Task<ICollection<HotelDto>> GetAllAsync()
        {
            var hotels = await _hotelRepository.SelectAllAsync();
            return hotels.Select(_mapper.Map<HotelDto>).ToList();
        }

        public async Task<HotelDto> GetByIdAsync(long id)
        {
            var hotel = await _hotelRepository.SelectByIdAsync(id);
            if (hotel == null)
                throw new EntityNotFoundException("Hotel not found.");

            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<ICollection<HotelDto>> GetByLocationAsync(string location)
        {
            var hotels = await _hotelRepository.SelectByLocationAsync(location);
            return hotels.Select(_mapper.Map<HotelDto>).ToList();
        }

        public async Task DeleteAsync(long id)
        {
            var hotel = await _hotelRepository.SelectByIdAsync(id);
            if (hotel == null)
                throw new EntityNotFoundException("Hotel not found.");

            await _hotelRepository.RemoveAsync(id);
            await _hotelRepository.SaveChangesAsync(); // Qo‘shildi
        }

        public async Task UpdateAsync(HotelUpdateDto hotelDto)
        {
            var hotel = await _hotelRepository.SelectByIdAsync(hotelDto.HotelId);
            if (hotel == null)
                throw new EntityNotFoundException("Hotel not found.");

            _mapper.Map(hotelDto, hotel);

            await _hotelRepository.UpdateAsync(hotel);
            await _hotelRepository.SaveChangesAsync(); // Qo‘shildi
        }
    }
}
