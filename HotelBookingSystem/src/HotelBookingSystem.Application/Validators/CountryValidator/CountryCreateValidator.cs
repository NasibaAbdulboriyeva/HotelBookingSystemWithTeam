using FluentValidation;
using HotelBookingSystem.Application.Dtos.CountryDto;

namespace HotelBookingSystem.Application.Validators.CountryValidator
{
    public class CountryCreateValidator : AbstractValidator<CountryCreateDto>
    {
        public CountryCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Country name is required.")
                .MaximumLength(100).WithMessage("Country name must not exceed 100 characters.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Country code is required.")
                .Length(2).WithMessage("Country code must be exactly 2 characters."); // ISO alpha-2 (UZ, US, etc.)

            RuleFor(x => x.PhoneCode)
                .MaximumLength(10).WithMessage("Phone code must not exceed 10 characters.");

            RuleFor(x => x.Currency)
                .MaximumLength(10).WithMessage("Currency must not exceed 10 characters.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive field is required.");
        }
    }
}
