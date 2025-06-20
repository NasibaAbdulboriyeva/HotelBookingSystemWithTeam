using AutoMapper;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;
public class CardMapper : Profile
{
    public CardMapper()
    {
        CreateMap<Card, CardDto>().ReverseMap();
        CreateMap<Card, CreateCardDto>().ReverseMap();
    }
}