using AutoMapper;
using HotelBookingSystem.Application.Dtos.CountryDto;
using HotelBookingSystem.Application.Dtos.RoomPhotoDto;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Mappings
{
    public class RoomPhotoMapper : Profile
    {
        public RoomPhotoMapper()
        {
            CreateMap<RoomPhoto, RoomPhotoDto>().ReverseMap();
            CreateMap<RoomPhoto, UpdateRoomPhotoDto>().ReverseMap();
            CreateMap<RoomPhoto, CreateRoomPhotoDto>().ReverseMap();
        }
    }
}
