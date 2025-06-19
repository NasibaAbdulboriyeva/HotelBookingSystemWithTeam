using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IComplaintRepository
{
    Task<Complaint> SelectByIdAsync(long id);
    Task<ICollection<Complaint>> SelectByHotelIdAsync(long hotelId);
    Task<ICollection<Complaint>> SelectByUserIdAsync(long userId);
    Task<long> InsertAsync(Complaint complaint);
    Task<ICollection<Complaint>> SelectByStatusAsync(ComplaintStatus status);
    Task UpdateStatusAsync(long complaintId);
}
