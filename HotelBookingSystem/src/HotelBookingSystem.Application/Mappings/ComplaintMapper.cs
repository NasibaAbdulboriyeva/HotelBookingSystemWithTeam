using AutoMapper;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Mappings
{
    public class ComplaintMapper : Profile
    {
        public ComplaintMapper()
        {
            CreateMap<Complaint, ComplaintDto>().ReverseMap();
            CreateMap<Complaint, CreateComplaintDto>().ReverseMap();
        }
    
    }
}
