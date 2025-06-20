using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Application.Services.ComplaintService;
using HotelBookingSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/complaint")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

       
        [HttpPost("addComplaint")]
        public async Task<long> AddComplaint([FromBody] CreateComplaintDto createComplaintDto)
        {
            var id = await _complaintService.AddComplaintAsync(createComplaintDto);
            return id;
        }

        
        [HttpGet("getComplaintById")]
        public async Task<ComplaintDto> GetById(long id)
        {
            var complaintDto = await _complaintService.GetByIdAsync(id);
            return complaintDto;
        }

        [HttpGet("getComplaintsByHotelId")]
        public async Task<ICollection<ComplaintDto>>GetByHotelId(long hotelId)
        {
            var complaintDtos = await _complaintService.GetByHotelIdAsync(hotelId);
            return complaintDtos;
        }

        [HttpGet("getComplaintsByUserId")]
        public async Task<ICollection<ComplaintDto>>GetByUserId(long userId)
        {
            var complaintDtos = await _complaintService.GetByUserIdAsync(userId);
            return complaintDtos;
        }

      
        [HttpGet("getAllComplaints")]
        public async Task<ICollection<ComplaintDto>> GetAll()
        {
            var complaintDtos = await _complaintService.GetAllAsync();
            return complaintDtos;
        }

        [HttpGet("getComplaintsByStatus")]
        public async Task<ICollection<ComplaintDto>> GetByStatus(ComplaintStatus status)
        {
            var complaintDtos = await _complaintService.GetByStatusAsync(status);
            return complaintDtos;
        }

        [HttpPut("updateComplaint")]
        public async Task Update(long id,  CreateComplaintDto updateDto)
        {
            await _complaintService.UpdateAsync(id, updateDto);
           
        }

       
        [HttpDelete("deleteComplaint")]
        public async Task Delete(long id)
        {
            await _complaintService.DeleteAsync(id);
          
        }
    }
}
