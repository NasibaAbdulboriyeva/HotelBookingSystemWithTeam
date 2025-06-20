using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Services.CardServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService CardService;

        public CardController(ICardService cardService)
        {
            CardService = cardService;
        }

        [HttpPost("create")]
        public  Task<long> CreateCardAsync(CreateCardDto createCardDto)
        {
            return CardService.CreateCardAsync(createCardDto);
        }

        [HttpGet("getCardsByUserId")]
        public async Task<ICollection<CardDto>> GetCardsByUserIdAsync(long userId)
        {
            return await CardService.GetCardsByUserIdAsync(userId);
        }

        [HttpPut("selectCardForPaymentAsync")]
        public async Task SelectCardForPaymentAsync(long cardId, long userId)
        {
            await CardService.SelectCardForPaymentAsync(cardId, userId);
        }

        [HttpDelete("deleteCardAsync")]
        public async Task DeleteCardAsync(long cardId, long userId)
        {
            await CardService.DeleteCardAsync(cardId, userId);
        }
    }
}