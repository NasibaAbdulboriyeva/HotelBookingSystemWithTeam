using AutoMapper;
using HotelBookingSystem.Application.Dtos.CountryDto;
using HotelBookingSystem.Application.Dtos.RoomTypeDto;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Mappings
{
    public class RoomTypeMapper : Profile
    {
        public RoomTypeMapper()
        {
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeUpdateDto>().ReverseMap();
            CreateMap<RoomType, CreateRoomTypeDto>().ReverseMap();
        }
    }
}
