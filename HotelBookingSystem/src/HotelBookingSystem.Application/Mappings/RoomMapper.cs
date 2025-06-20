using AutoMapper;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Mappings;
public class RoomMapper : Profile
{
    public RoomMapper()
    {
        CreateMap<CreateRoomDto, Room>().ReverseMap();
        CreateMap<RoomDto, Room>().ReverseMap();
    }
}
