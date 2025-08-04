using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.ReviewService;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateReviewDto> _createReviewDtoValidator;

    public ReviewService(
        IReviewRepository reviewRepository,
        IHotelRepository hotelRepository,
        IMapper mapper,
        IUserRepository userRepository,
        IValidator<CreateReviewDto> createReviewDtoValidator)
    {
        _reviewRepository = reviewRepository;
        _hotelRepository = hotelRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _createReviewDtoValidator = createReviewDtoValidator;
    }

    public async Task<long> CreateReviewAsync(CreateReviewDto createReviewDto)
    {
        ArgumentNullException.ThrowIfNull(createReviewDto);

        var validationResult = await _createReviewDtoValidator.ValidateAsync(createReviewDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var hotel = await _hotelRepository.SelectByIdAsync(createReviewDto.HotelId);
        if (hotel is null)
            throw new NotFoundException($"Hotel with ID {createReviewDto.HotelId} not found.");

        var user = await _userRepository.SelectByIdAsync(createReviewDto.UserId);
        if (user is null)
            throw new NotFoundException($"User with ID {createReviewDto.UserId} not found.");

        var review = _mapper.Map<Review>(createReviewDto);
        await _reviewRepository.InsertAsync(review);
        await _reviewRepository.SaveChangesAsync();

        return review.ReviewId;
    }

    public async Task DeleteReviewAsync(long userId, long reviewId)
    {
        var review = await _reviewRepository.SelectByIdAsync(reviewId);
        if (review == null)
            throw new NotFoundException($"Review with ID {reviewId} not found.");

        if (review.UserId != userId)
            throw new UnauthorizedException("You are not authorized to delete this review.");

        await _reviewRepository.RemoveAsync(reviewId);
        await _reviewRepository.SaveChangesAsync(); // <-- Muhim
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
            throw new NotFoundException($"No reviews found for hotel with ID {hotelId}.");

        return _mapper.Map<ICollection<ReviewDto>>(reviews);
    }

    public async Task<ICollection<ReviewDto>> GetReviewsByUserIdAsync(long userId)
    {
        var reviews = await _reviewRepository.SelectByUserIdAsync(userId);
        if (reviews == null || reviews.Count == 0)
            throw new NotFoundException($"No reviews found for user with ID {userId}.");

        return _mapper.Map<ICollection<ReviewDto>>(reviews);
    }
}
