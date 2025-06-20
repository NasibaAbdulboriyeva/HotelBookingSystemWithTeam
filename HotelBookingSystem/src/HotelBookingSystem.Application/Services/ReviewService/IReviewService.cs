using HotelBookingSystem.Application.Dtos.ReviewDtos;

namespace HotelBookingSystem.Application.Services.ReviewService;

public interface IReviewService
{
    Task<long> CreateReviewAsync(CreateReviewDto createReviewDto);
    Task DeleteReviewAsync(long userId, long reviewId);
    Task<ICollection<ReviewDto>> GetReviewsByHotelIdAsync(long hotelId);
    Task<ICollection<ReviewDto>> GetReviewsByUserIdAsync(long userId);
    Task<ReviewDto> GetReviewByIdAsync(long reviewId);
}