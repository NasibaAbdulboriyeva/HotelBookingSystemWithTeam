using AutoMapper;
using HotelBookingSystem.Application.Dtos.ServiceDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;
public class ServiceMapper : Profile
{
    public ServiceMapper()
    {
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<Service, CreateServiceDto>().ReverseMap();
    }
}

