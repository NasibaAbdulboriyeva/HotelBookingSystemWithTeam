using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Application.Services.HotelService;
using HotelBookingSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpPost("addHotel")]
        public async Task<long> AddComplaint( CreateHotelDto createHotelDto)
        {
            var id = await _hotelService.AddAsync(createHotelDto);
            return id;
        }


        [HttpGet("getHotelById")]
        public async Task<HotelDto> GetById(long id)
        {
            var hotelDtos = await _hotelService.GetByIdAsync(id);
            return hotelDtos;
        }

        [HttpGet("getHotelsByLocation")]
        public async Task<ICollection<HotelDto>> GetByLocation(string location)
        {
            var hotelDtos = await _hotelService.GetByLocationAsync(location);
            return hotelDtos;
        }

      

        [HttpGet("getAllHotels")]
        public async Task<ICollection<HotelDto>> GetAll()
        {
            var hotelDtos = await _hotelService.GetAllAsync();
            return hotelDtos;
        }

        
        [HttpPut("updateHotel")]
        public async Task Update(HotelDto updateDto)
        {
            await _hotelService.UpdateAsync(updateDto);

        }


        [HttpDelete("deleteHotel")]
        public async Task Delete(long id)
        {
            await _hotelService.DeleteAsync(id);

        }
    }
}
