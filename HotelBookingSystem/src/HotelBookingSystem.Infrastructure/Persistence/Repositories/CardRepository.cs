using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories
{
    public class CardRepository : ICardRepository
    {

        private readonly AppDbContext _appDbContext;

        public CardRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AssignCardAsNotSelectedAsync(long cardId)
        {
            var card = await _appDbContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);
            if (card != null)
            {
                card.SelectedForPayment = false;
            }
        }

        public async Task AssignCardAsSelectedAsync(long cardId)
        {
            var card = await _appDbContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);
            if (card != null)
            {
                card.SelectedForPayment = true;
            }
        }

        public async Task DeleteAsync(long id)
        {
            var card = await _appDbContext.Cards.FirstOrDefaultAsync(c => c.CardId == id);
            if (card == null)
            {
                throw new KeyNotFoundException($"Card with ID {id} not found.");
            }
            _appDbContext.Cards.Remove(card);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<long> InsertAsync(Card card)
        {
            await _appDbContext.Cards.AddAsync(card);
            return card.CardId;
        }

        public async Task<ICollection<Card>> SelectAllAsync()
        {
            return await _appDbContext.Cards.ToListAsync();
        }

        public async Task<Card> SelectByIdAsync(long id)
        {
            var card = await _appDbContext.Cards
            .FirstOrDefaultAsync(r => r.CardId == id);
            if (card == null)
            {
                throw new KeyNotFoundException($"Card with ID {id} not found.");
            }
            return card;
        }

        public async Task<Card> SelectSelectedCardByUserIdAsync(long userId)
        {
            var card = await _appDbContext.Cards
                  .FirstOrDefaultAsync(u => u.UserId == userId);
            if(card == null)
            {
                throw new KeyNotFoundException($"Card for user with ID {userId} not found.");
            }

            return card;
        }
        public async Task <ICollection<Card>> SelectCardsByUserIdAsync(long userId)
        {
            return await _appDbContext.Cards
                .Where(c => c.User.UserId == userId)
                .ToListAsync();
        }
        public async Task AssignCardsAsNotSelectedAsync(ICollection<Card> cards)
        {
            if (cards == null || cards.Count == 0)
                return;

            foreach (var card in cards)
            {
                card.SelectedForPayment = false;
            }
            await _appDbContext.SaveChangesAsync();

        }
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
