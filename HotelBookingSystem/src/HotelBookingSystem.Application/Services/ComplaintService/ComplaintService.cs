using AutoMapper;
using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Services.ComplaintService
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;

        public ComplaintService(IComplaintRepository complaintRepository, IMapper mapper)
        {
            _complaintRepository = complaintRepository;
            _mapper = mapper;
        }

        public async Task<long> AddComplaintAsync(CreateComplaintDto createComplaintDto)
        {
            ArgumentNullException.ThrowIfNull(createComplaintDto);
            var complaint = _mapper.Map<Complaint>(createComplaintDto);
            complaint.Status = ComplaintStatus.InReview;
            complaint.CreatedAt = DateTime.UtcNow;
            return await _complaintRepository.InsertAsync(complaint);
        }

        public async Task<ComplaintDto> GetByIdAsync(long id)
        {
            var complaint = await _complaintRepository.SelectByIdAsync(id);
            if (complaint == null)
            {
                throw new EntityNotFoundException("Complaint not found.");
            }

            return _mapper.Map<ComplaintDto>(complaint);
        }

        public async Task<ICollection<ComplaintDto>> GetByHotelIdAsync(long hotelId)
        {
            var complaints = await _complaintRepository.SelectByHotelIdAsync(hotelId);
            return complaints.Select(_mapper.Map<ComplaintDto>).ToList();
        }

        public async Task<ICollection<ComplaintDto>> GetByUserIdAsync(long userId)
        {
            var complaints = await _complaintRepository.SelectByUserIdAsync(userId);
            return complaints.Select(_mapper.Map<ComplaintDto>).ToList();
        }

        public async Task<ICollection<ComplaintDto>> GetAllAsync()
        {
            var complaints = await _complaintRepository.SelectAllAsync();
            return complaints.Select(_mapper.Map<ComplaintDto>).ToList();
        }

        public async Task<ICollection<ComplaintDto>> GetByStatusAsync(ComplaintStatus status)
        {
            var complaints = await _complaintRepository.SelectByStatusAsync(status);
            return complaints.Select(_mapper.Map<ComplaintDto>).ToList();
        }

        public async Task UpdateAsync( ComplaintDto updateComplaintDto)
        {
            var complaint = await _complaintRepository.SelectByIdAsync(updateComplaintDto.ComplaintId);
            if (complaint == null)
            {
                throw new EntityNotFoundException("Complaint not found.");
            }

            complaint.Status = ComplaintStatus.Resolved;
            await _complaintRepository.UpdateAsync(complaint);
        }

        public async Task DeleteAsync(long complaintId)
        {
            var complaint = await _complaintRepository.SelectByIdAsync(complaintId);
            if (complaint == null)
            {
                throw new EntityNotFoundException("Complaint not found.");
            }


            await _complaintRepository.RemoveAsync(complaintId);
        }
    }

}
