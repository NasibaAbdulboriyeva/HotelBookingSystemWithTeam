using AutoMapper;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;

public class ReviewMapper : Profile
{
    public ReviewMapper()
    {
        CreateMap<CreateReviewDto, Review>().ReverseMap();
        CreateMap<Review, ReviewDto>().ReverseMap();
    }
}