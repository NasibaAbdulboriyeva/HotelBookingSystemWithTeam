using FluentValidation;
using HotelBookingSystem.Application.Dtos.HotelDtos;

namespace HotelBookingSystem.Application.Validators.HotelValidator;
public class HotelCreateValidator : AbstractValidator<CreateHotelDto>
{
    public HotelCreateValidator()
    {
        RuleFor(x => x.HotelName)
            .NotEmpty().WithMessage("Hotel name is required.")
            .MaximumLength(50).WithMessage("Hotel name must not exceed 100 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Hotel address is required.")
            .MaximumLength(200).WithMessage("Hotel address must not exceed 200 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be a valid international format.");
    }
}

