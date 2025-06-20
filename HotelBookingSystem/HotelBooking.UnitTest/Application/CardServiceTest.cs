using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Mappings;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.CardServices;
using HotelBookingSystem.Domain.Entities;
using Moq;

namespace HotelBooking.UnitTest.Application;
public class CardServiceTest
{
    private readonly CardService _cardService;
    private readonly Mock<ICardRepository> _cardRepositoryMock;
    private readonly Mock<IValidator<CreateCardDto>> _createCardDtoValidatorMock;
    private readonly IMapper _mapper;

    public CardServiceTest()
    {
        _cardRepositoryMock = new Mock<ICardRepository>();
        _createCardDtoValidatorMock = new Mock<IValidator<CreateCardDto>>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CardMapper>();
        });
        _mapper = config.CreateMapper();

        _cardService = new CardService(
            _cardRepositoryMock.Object,
            _mapper,
            _createCardDtoValidatorMock.Object
        );
    }

    [Fact]
    public async Task CreateCardAsync_ShouldReturnCardId_WhenCardIsCreatedSuccessfully()
    {
        // Arrange
        var createCardDto = new CreateCardDto
        {
            CardNumberMasked = "****-****-****-3456",
            ExpiryMonth = 12,
            ExpiryYear = 2027,
            CVV = "123",
            UserId = 1
        };

        var existingCards = new List<Card>();

        _createCardDtoValidatorMock
            .Setup(v => v.ValidateAsync(createCardDto, default))
            .ReturnsAsync(new ValidationResult());

        _cardRepositoryMock
            .Setup(r => r.SelectCardsByUserIdAsync(createCardDto.UserId))
            .ReturnsAsync(existingCards);

        _cardRepositoryMock
            .Setup(r => r.AssignCardsAsNotSelectedAsync(It.IsAny<ICollection<Card>>()))
            .Returns(Task.CompletedTask);

        _cardRepositoryMock
            .Setup(r => r.InsertAsync(It.IsAny<Card>()))
            .ReturnsAsync(10L);

        // Act
        var result = await _cardService.CreateCardAsync(createCardDto);

        // Assert
        Assert.Equal(10L, result);
    }

    [Fact]
    public async Task GetCardsByUserIdAsync_ShouldReturnCardDtos_WhenCardsExistForUserId()
    {
        // Arrange
        long userId = 1;
        var cards = new List<Card>
        {
            new Card { CardId = 1, UserId = userId, CardNumberMasked = "****-****-****-1234" },
            new Card { CardId = 2, UserId = userId, CardNumberMasked = "****-****-****-5678" }
        };
        _cardRepositoryMock
            .Setup(r => r.SelectCardsByUserIdAsync(userId))
            .ReturnsAsync(cards);
        // Act
        var result = await _cardService.GetCardsByUserIdAsync(userId);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.All(result, card => Assert.Contains("****-****-****", card.CardNumberMasked));
    }

    [Fact]
    public async Task DeleteCardAsync_ShouldCallDeleteAsync_WhenCardExists()
    {
        // Arrange
        long cardId = 1L;
        long userId = 1L;
        var existingCard = new Card { CardId = cardId, UserId = userId };
        var userCards = new List<Card> { existingCard };

        _cardRepositoryMock
            .Setup(r => r.SelectCardsByUserIdAsync(userId))
            .ReturnsAsync(userCards);

        _cardRepositoryMock
            .Setup(r => r.DeleteAsync(cardId))
            .Returns(Task.CompletedTask);

        // Act
        await _cardService.DeleteCardAsync(cardId,userId);

        // Assert
        _cardRepositoryMock.Verify(r => r.DeleteAsync(cardId), Times.Once);
    }
}

