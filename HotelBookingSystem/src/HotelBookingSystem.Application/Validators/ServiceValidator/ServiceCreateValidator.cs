using FluentValidation;
using HotelBookingSystem.Application.Dtos.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.ServiceValidator
{
    public class ServiceCreateValidator : AbstractValidator<CreateServiceDto>
    {
        public ServiceCreateValidator()
        {
            RuleFor(x => x.ServiceName)
                .NotEmpty().WithMessage("Service name is required.")
                .MaximumLength(100).WithMessage("Service name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative.");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Hotel ID must be valid.");
        }
    }
}
