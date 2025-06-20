using AutoMapper;
using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.HotelService
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<long> AddAsync(CreateHotelDto createHotelDto)
        {
            ArgumentNullException.ThrowIfNull(createHotelDto);
            var hotel = _mapper.Map<Hotel>(createHotelDto);
         
            return await _hotelRepository.InsertAsync(hotel);
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
            {
                throw new EntityNotFoundException("Complaint not found.");
            }

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
            {
                throw new EntityNotFoundException("Complaint not found.");
            }


            await _hotelRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(HotelDto hotelDto)
        {
            var hotel = await _hotelRepository.SelectByIdAsync(hotelDto.HotelId);
            if (hotel == null)
            {
                throw new EntityNotFoundException("Complaint not found.");
            }

            await _hotelRepository.UpdateAsync(hotel);
        }
    }
}
