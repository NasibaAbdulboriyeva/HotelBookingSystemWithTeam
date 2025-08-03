using AutoMapper;
using HotelBookingSystem.Application.Dtos.PaymentDtos;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Mappings;
public class PaymentMapper : Profile
{
    public PaymentMapper()
    {
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Payment, PaymentUpdateDto>().ReverseMap();
        CreateMap<Payment, CreatePaymentDto>().ReverseMap();
    }
}
