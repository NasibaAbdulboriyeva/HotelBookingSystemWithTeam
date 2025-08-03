using FluentValidation;
using HotelBookingSystem.Application.Dtos.CityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.CityValidator
{
    public class CityCreateValidator : AbstractValidator<CreateCityDto>
    {
        public CityCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is required.")
                .MaximumLength(100).WithMessage("City name must not exceed 100 characters.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Country ID must be a valid positive number.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive field is required.");
        }
    }
}
