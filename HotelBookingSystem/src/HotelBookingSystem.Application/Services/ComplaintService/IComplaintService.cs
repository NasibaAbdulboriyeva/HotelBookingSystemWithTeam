using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Services.ComplaintService
{
    public interface IComplaintService
    {
        Task<long> AddComplaintAsync(CreateComplaintDto createComplaintDto);
        Task<ComplaintDto> GetByIdAsync(long id);
        Task<ICollection<ComplaintDto>> GetByHotelIdAsync(long hotelId);
        Task<ICollection<ComplaintDto>> GetByUserIdAsync(long userId);
        Task<ICollection<ComplaintDto>> GetAllAsync();
        Task<ICollection<ComplaintDto>> GetByStatusAsync(ComplaintStatus status);
        Task UpdateAsync(ComplaintDto updateComplaintDto );
        Task DeleteAsync(long complaintId);
    }
}