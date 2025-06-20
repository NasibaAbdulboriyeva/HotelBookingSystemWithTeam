using HotelBookingSystem.Application.Dtos.CardDtos;

namespace HotelBookingSystem.Application.Services.CardServices
{
    public interface ICardService
    {
        Task<long> CreateCardAsync(CreateCardDto createCardDto);
        Task<ICollection<CardDto>> GetCardsByUserIdAsync(long userId);
        Task SelectCardForPaymentAsync(long cardId, long userId);
        Task DeleteCardAsync(long cardId, long userId);
    }
}