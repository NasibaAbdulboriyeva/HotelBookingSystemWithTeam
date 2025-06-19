using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface ICardRepository
{
    Task<Card> SelectByIdAsync(long id);
    Task<ICollection<Card>> SelectAllCardsAsync();
    Task InsertAsync(Card card);
    Task<Card> SelectSelectedCardByUserIdAsync(long userId);
    Task AssignCardAsSelectedAsync(long cardId);
    Task AssignCardAsNotSelectedAsync(long cardId);
    Task DeleteAsync(long id);
}
