using AutoMapper;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.ReviewService;
public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ReviewService(IReviewRepository reviewRepository, IHotelRepository hotelRepository, IMapper mapper, IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _hotelRepository = hotelRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<long> CreateReviewAsync(CreateReviewDto createReviewDto)
    {
        var hotel = await _hotelRepository.SelectByIdAsync(createReviewDto.HotelId);
        if (hotel == null)
        {
            throw new NotFoundException($"Hotel with ID {createReviewDto.HotelId} not found.");
        }

        var user = await _userRepository.SelectByIdAsync(createReviewDto.UserId);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {createReviewDto.UserId} not found.");
        }

        var review = _mapper.Map<Review>(createReviewDto);
        var hotelId = createReviewDto.HotelId;

        await _reviewRepository.InsertAsync(review);

        return review.ReviewId;
    }

    public async Task DeleteReviewAsync(long userId, long reviewId)
    {
        var review = await GetReviewByIdAsync(reviewId);
        if (review.UserId != userId)
        {
            throw new ForbiddenException("You can't delete someone else's review.");
        }
        await _reviewRepository.RemoveAsync(reviewId);
    }

    public async Task<ReviewDto> GetReviewByIdAsync(long reviewId)
    {
        var review = await _reviewRepository.SelectByIdAsync(reviewId);

        return _mapper.Map<ReviewDto>(review);
    }

    public async Task<ICollection<ReviewDto>> GetReviewsByHotelIdAsync(long hotelId)
    {
       var reviews = await _reviewRepository.SelectByHotelIdAsync(hotelId);
        if (reviews == null || reviews.Count == 0)
        {
            throw new NotFoundException($"No reviews found for hotel with ID {hotelId}.");
        }
        return _mapper.Map<ICollection<ReviewDto>>(reviews);
    }

    public async Task<ICollection<ReviewDto>> GetReviewsByUserIdAsync(long userId)
    {
        var reviews = await _reviewRepository.SelectByUserIdAsync(userId);
        if (reviews == null || reviews.Count == 0)
        {
            throw new NotFoundException($"No reviews found for user with ID {userId}.");
        }
        return _mapper.Map<ICollection<ReviewDto>>(reviews);
    }
}
