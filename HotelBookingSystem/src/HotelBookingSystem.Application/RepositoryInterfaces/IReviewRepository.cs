using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IReviewRepository
{
    Task<Review> SelectByIdAsync(long id);

    Task<IEnumerable<Review>> SelectByHotelIdAsync(long hotelId);

    Task<IEnumerable<Review>> SelectByUserIdAsync(long userId);
    Task<ICollection<Review>> SelectAllAsync();

    Task<long> InsertAsync(Review review);
}

