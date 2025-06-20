using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IReviewRepository
{
    Task<Review> SelectByIdAsync(long id);

    Task<ICollection<Review>> SelectByHotelIdAsync(long hotelId);

    Task<ICollection<Review>> SelectByUserIdAsync(long userId);
    Task<ICollection<Review>> SelectAllAsync();

    Task<long> InsertAsync(Review review);
}

