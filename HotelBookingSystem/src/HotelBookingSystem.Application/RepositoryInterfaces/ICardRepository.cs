using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface ICardRepository
{
    Task<Card> SelectByIdAsync(long id);
    Task<ICollection<Card>> SelectAllAsync();
    Task<long> InsertAsync(Card card);
    Task<Card> SelectSelectedCardByUserIdAsync(long userId);
    Task AssignCardAsSelectedAsync(long cardId);
    Task AssignCardAsNotSelectedAsync(long cardId);
    Task AssignCardsAsNotSelectedAsync(ICollection<Card> cards);
    Task<ICollection<Card>> SelectCardsByUserIdAsync(long userId);
    Task DeleteAsync(long id);
    Task<int> SaveChangesAsync();
}
