using AutoMapper;
using HotelBookingSystem.Application.Dtos.CityDto;
using HotelBookingSystem.Application.Dtos.CountryDto;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Mappings
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CityUpdateDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
        }
    }
}
