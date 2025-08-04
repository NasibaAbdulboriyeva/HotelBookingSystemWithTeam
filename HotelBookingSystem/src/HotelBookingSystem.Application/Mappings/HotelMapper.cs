using AutoMapper;
using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;

public class HotelMapper : Profile
{
    public HotelMapper()
    {
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, HotelUpdateDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
    }
}

