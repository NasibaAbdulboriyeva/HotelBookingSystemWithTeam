using FluentValidation;
using HotelBookingSystem.Application.Dtos.CardDtos;

namespace HotelBookingSystem.Application.Validators.CardValidator;
public class CardCreateValidator : AbstractValidator<CreateCardDto>
{
    public CardCreateValidator()
    {
        RuleFor(x => x.CardNumber)
            .NotEmpty().WithMessage("Card number is required.")
            .CreditCard().WithMessage("Invalid card number format.");

        RuleFor(x => x.CardHolderName)
            .NotEmpty().WithMessage("Card holder name is required.")
            .MaximumLength(50).WithMessage("Card holder name must not exceed 100 characters.");

        RuleFor(x => x.ExpiryMonth)
            .InclusiveBetween(1, 12).WithMessage("Expiry month must be between 1 and 12.");

        RuleFor(x => x.ExpiryYear)
            .InclusiveBetween(DateTime.Now.Year, DateTime.Now.Year + 10)
            .WithMessage("Expiry year must be between the current year and the next 20 years.");

    }
    private bool BeAValidExpiryDate(DateTime expiryDate)
    {
        return expiryDate > DateTime.Now;
    }
}

