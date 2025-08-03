using AutoMapper;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.Dtos.CountryDto;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Mappings
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryUpdateDto>().ReverseMap();
            CreateMap<Country, CountryCreateDto>().ReverseMap();
        }
    }
}
