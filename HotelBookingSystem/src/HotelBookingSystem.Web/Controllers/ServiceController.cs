using HotelBookingSystem.Application.Dtos.ServiceDtos;
using HotelBookingSystem.Application.Services.AffairService;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        private readonly IAffairService _affairService;

        public ServiceController(IAffairService serviceService)
        {
            _affairService = serviceService;
        }

        [HttpPost("addService")]
        public async Task<long> Create([FromBody] CreateServiceDto createServiceDto)
        {
            return await _affairService.CreateAsync(createServiceDto);
        }

        [HttpGet("getServiceById")]
        public async Task<ServiceDto> GetById(long id)
        {
            return await _affairService.GetByIdAsync(id);
        }

        [HttpGet("getServicesByHotelId")]
        public async Task<ICollection<ServiceDto>> GetByHotelId(long hotelId)
        {
            return await _affairService.GetByHotelIdAsync(hotelId);
        }

        [HttpGet("getAllServices")]
        public async Task<ICollection<ServiceDto>> GetAll()
        {
            return await _affairService.GetAllAsync();
        }

        [HttpPut("updateService")]
        public async Task Update([FromBody] ServiceUpdateDto updateDto)
        {
            await _affairService.UpdateAsync(updateDto);
        }

        [HttpDelete("deleteService")]
        public async Task Delete(long id)
        {
            await _affairService.DeleteAsync(id);
        }
    }
}
