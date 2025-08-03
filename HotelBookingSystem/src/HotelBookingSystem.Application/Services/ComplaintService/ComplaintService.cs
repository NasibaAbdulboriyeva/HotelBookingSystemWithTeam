using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.CardDtos;
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
        private readonly IValidator<CreateComplaintDto> _createComplaintDtoValidator;

        public ComplaintService(
            IComplaintRepository complaintRepository,
            IMapper mapper,
            IValidator<CreateComplaintDto> createComplaintDtoValidator)
        {
            _complaintRepository = complaintRepository;
            _mapper = mapper;
            _createComplaintDtoValidator = createComplaintDtoValidator;
        }

        public async Task<long> AddComplaintAsync(CreateComplaintDto createComplaintDto)
        {
            ArgumentNullException.ThrowIfNull(createComplaintDto);

            var validationResult = await _createComplaintDtoValidator.ValidateAsync(createComplaintDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var complaint = _mapper.Map<Complaint>(createComplaintDto);
            complaint.Status = ComplaintStatus.InReview;
            complaint.CreatedAt = DateTime.UtcNow;

            await _complaintRepository.InsertAsync(complaint);
            await _complaintRepository.SaveChangesAsync(); // Qo‘shildi

            return complaint.ComplaintId;
        }

        public async Task<ComplaintDto> GetByIdAsync(long id)
        {
            var complaint = await _complaintRepository.SelectByIdAsync(id);
            if (complaint == null)
                throw new EntityNotFoundException("Complaint not found.");

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

        public async Task UpdateAsync(ComplaintDto updateComplaintDto)
        {
            var complaint = await _complaintRepository.SelectByIdAsync(updateComplaintDto.ComplaintId);
            if (complaint == null)
                throw new EntityNotFoundException("Complaint not found.");

            complaint.Status = ComplaintStatus.Resolved;
            await _complaintRepository.UpdateAsync(complaint);
            await _complaintRepository.SaveChangesAsync(); // Qo‘shildi
        }

        public async Task DeleteAsync(long complaintId)
        {
            var complaint = await _complaintRepository.SelectByIdAsync(complaintId);
            if (complaint == null)
                throw new EntityNotFoundException("Complaint not found.");

            await _complaintRepository.RemoveAsync(complaintId);
            await _complaintRepository.SaveChangesAsync(); // Qo‘shildi
        }
    }
}
