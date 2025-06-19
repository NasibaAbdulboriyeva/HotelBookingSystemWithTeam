using AutoMapper;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;
public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
