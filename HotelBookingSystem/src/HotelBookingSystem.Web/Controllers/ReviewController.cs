using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using HotelBookingSystem.Application.Services.CardServices;
using HotelBookingSystem.Application.Services.ReviewService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost("create")]
    public async Task<long> Create(CreateReviewDto createReviewDto)
    {
       return await _reviewService.CreateReviewAsync(createReviewDto);
    }

    [HttpDelete("delete")]
    public async Task Delete(long userId, long reviewId)
    {
        await _reviewService.DeleteReviewAsync(userId, reviewId);
    }

    [HttpGet("get-by-hotel-id")]
    public async Task<ICollection<ReviewDto>> GetByHotelId(long hotelId)
    {
        return await _reviewService.GetReviewsByHotelIdAsync(hotelId);
    }

    [HttpGet("get-by-user-id")]
    public async Task<ICollection<ReviewDto>> GetByUserId(long userId)
    {
        return await _reviewService.GetReviewsByUserIdAsync(userId);
    }
}
