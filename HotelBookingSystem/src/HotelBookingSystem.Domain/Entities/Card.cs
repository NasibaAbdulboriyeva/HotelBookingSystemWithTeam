using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Domain.Entities;

public class Card
{
    public long CardId { get; set; }
    public string CardNumberMasked { get; set; }
    public string CardHolderName { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public CardType Type { get; set; }
    public bool SelectedForPayment { get; set; }
    public string CVV { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
