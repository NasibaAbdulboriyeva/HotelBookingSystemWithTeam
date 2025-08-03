using AutoMapper;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;
public class BookingMapper : Profile
{
    public BookingMapper()
    {
        CreateMap<Booking, BookingDto>().ReverseMap();
        CreateMap<Booking, BookingUpdateDto>().ReverseMap();
        CreateMap<Booking, CreateBookingDto>().ReverseMap();
    }
}

