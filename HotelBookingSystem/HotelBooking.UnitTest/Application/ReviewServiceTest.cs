using AutoMapper;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using HotelBookingSystem.Application.Mappings;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.ReviewService;
using HotelBookingSystem.Domain.Entities;
using Moq;

namespace HotelBooking.UnitTest.Application;
public class ReviewServiceTest
{
    private readonly ReviewService _reviewService;
    private readonly Mock<IReviewRepository> _reviewRepository;
    private readonly Mock<IHotelRepository> _hotelRepository;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly IMapper _mapper;

    public ReviewServiceTest()
    {
        _reviewRepository = new Mock<IReviewRepository>();
        _hotelRepository = new Mock<IHotelRepository>();
        _userRepository = new Mock<IUserRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ReviewMapper>(); 
        });
        _mapper = config.CreateMapper();

        _reviewService = new ReviewService(
            _reviewRepository.Object,
            _hotelRepository.Object,
            _mapper,
            _userRepository.Object
        );
    }

    [Fact]
    public async Task GetReviewById_ShouldReturnReviewDto_WhenReviewExists()
    {
        // Arrange
        long reviewId = 1;
        var review = new Review
        {
            ReviewId = reviewId,
            Rating = 5,
            Comment = "Juda yaxshi mehmonxona!",
            CreatedAt = DateTime.UtcNow,
            IsVisible = true,
            HotelId = 100,
            UserId = 200
        };

        _reviewRepository
            .Setup(r => r.SelectByIdAsync(reviewId))
            .ReturnsAsync(review);

        // Act
        var result = await _reviewService.GetReviewByIdAsync(reviewId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(reviewId, result.ReviewId);
        Assert.Equal("Juda yaxshi mehmonxona!", result.Comment);
        Assert.Equal(5, result.Rating);
    }

    [Fact]
    public async Task CreateReview_ShouldReturnReviewId_WhenReviewIsCreatedSuccessfully()
    {
        // Arrange
        var user = new User
        {
            UserId = 200,
            FirstName = "Akhliddin",
            LastName = "Fahriddinov"
        };
        var hotel = new Hotel
        {
            HotelId = 100,
            HotelName = "Test Hotel",
            Location = "Test Address",
        };
        var createReviewDto = new CreateReviewDto
        {
            Rating = 5,
            Comment = "Juda yaxshi mehmonxona!",
            HotelId = 100,
            UserId = 200
        };
        var review = new Review
        {
            ReviewId = 1,
            Rating = 5,
            Comment = "Juda yaxshi mehmonxona!",
            HotelId = 100,
            UserId = 200,
        };

        _hotelRepository
         .Setup(h => h.SelectByIdAsync(100))
         .ReturnsAsync(hotel);

        _userRepository
         .Setup(u => u.SelectByIdAsync(200))
         .ReturnsAsync(user);

        _reviewRepository
          .Setup(r => r.InsertAsync(It.IsAny<Review>()))
          .ReturnsAsync(1);
        // Act
        var result = await _reviewService.CreateReviewAsync(createReviewDto);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task DeleteReview_ShouldCallRemoveAsync_WhenReviewExists()
    {
        // Arrange

        var user = new User
        {
            UserId = 200,
            FirstName = "Akhliddin",
            LastName = "Fahriddinov"
        };

        var hotel = new Hotel
        {
            HotelId = 100,
            HotelName = "Test Hotel",
            Location = "Test Address",
        };

        var review = new Review
        {
            ReviewId = 1,
            Rating = 5,
            Comment = "Zo‘r joy",
            HotelId = 100,
            UserId = 200
        };

        _userRepository
            .Setup(u => u.SelectByIdAsync(200))
            .ReturnsAsync(user);

        _hotelRepository
            .Setup(h => h.SelectByIdAsync(100))
            .ReturnsAsync(hotel);

        _reviewRepository
            .Setup(r => r.SelectByIdAsync(1))
            .ReturnsAsync(review);
  
        _reviewRepository
            .Setup(r => r.RemoveAsync(1))
            .Returns(Task.CompletedTask);

        // Act
        await _reviewService.DeleteReviewAsync(200,1);

        // Assert
        _reviewRepository.Verify(r => r.RemoveAsync(1), Times.Once);
    }
}





