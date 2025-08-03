using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.CardServices;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCardDto> _createCardDtoValidator;

    public CardService(
        ICardRepository cardRepository,
        IMapper mapper,
        IValidator<CreateCardDto> createCardDtoValidator)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
        _createCardDtoValidator = createCardDtoValidator;
    }

    public async Task<long> CreateCardAsync(CreateCardDto createCardDto)
    {
        ArgumentNullException.ThrowIfNull(createCardDto);

        var validationResult = await _createCardDtoValidator.ValidateAsync(createCardDto);
        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Validation failed: {errors}");
        }

        var existingCards = await _cardRepository.SelectCardsByUserIdAsync(createCardDto.UserId);

        foreach (var card in existingCards)
        {
            if (card.CardNumberMasked == createCardDto.CardNumberMasked)
                throw new ValidationException("Card with this number already exists.");
        }

        if (existingCards.Count() >= 5)
            throw new ValidationException("You can only save up to 5 cards.");

        var selectedCards = existingCards.Where(c => c.SelectedForPayment).ToList();
        await _cardRepository.AssignCardsAsNotSelectedAsync(selectedCards);

        var cardEntity = _mapper.Map<Card>(createCardDto);
        cardEntity.SelectedForPayment = true;

        await _cardRepository.InsertAsync(cardEntity);
        await _cardRepository.SaveChangesAsync();

        return cardEntity.CardId;
    }

    public async Task DeleteCardAsync(long cardId, long userId)
    {
        var cards = await _cardRepository.SelectCardsByUserIdAsync(userId);
        var toDelete = cards.FirstOrDefault(c => c.CardId == cardId);

        if (toDelete is null)
            throw new InvalidOperationException("Card isn't found or doesn't belong to this user");

        await _cardRepository.DeleteAsync(cardId);

        if (toDelete.SelectedForPayment)
        {
            var anotherCard = cards.FirstOrDefault(c => c.CardId != cardId);
            if (anotherCard != null)
                await _cardRepository.AssignCardAsSelectedAsync(anotherCard.CardId);
        }

        await _cardRepository.SaveChangesAsync(); // YANGI QO‘SHILDI
    }

    public async Task<ICollection<CardDto>> GetCardsByUserIdAsync(long userId)
    {
        var allCards = await _cardRepository.SelectCardsByUserIdAsync(userId);
        return _mapper.Map<ICollection<CardDto>>(allCards);
    }

    public async Task SelectCardForPaymentAsync(long cardId, long userId)
    {
        var allCards = await _cardRepository.SelectCardsByUserIdAsync(userId);
        var existCard = allCards.FirstOrDefault(c => c.CardId == cardId);

        if (existCard == null)
            throw new InvalidOperationException("Card isn't found or doesn't belong to this user");

        foreach (var card in allCards)
            await _cardRepository.AssignCardAsNotSelectedAsync(card.CardId);

        await _cardRepository.AssignCardAsSelectedAsync(cardId);
        await _cardRepository.SaveChangesAsync(); // YANGI QO‘SHILDI
    }
}
