using FluentValidation;
using HotelBookingSystem.Application.Dtos.PaymentDtos;

namespace HotelBookingSystem.Application.Validators.PaymentValidator;
public class PaymentCreateValidator : AbstractValidator<CreatePaymentDto>
{
    public PaymentCreateValidator()
    {
        RuleFor(x => x.PaidAmount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(x => x.PaymentMethod)
            .NotEmpty().WithMessage("Payment method is required.")
            .IsInEnum().WithMessage("Invalid payment method specified.");

     
    }
}

