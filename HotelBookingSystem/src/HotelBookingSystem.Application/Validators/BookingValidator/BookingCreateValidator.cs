using FluentValidation;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.Validators.PaymentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.BookingValidator
{
    public class BookingCreateValidator : AbstractValidator<CreateBookingDto>
    {
        public BookingCreateValidator()
        {
            RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Start date cannot be in the past.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User ID must be a valid positive number.");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Hotel ID must be a valid positive number.");

            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("Room ID must be a valid positive number.");

            RuleFor(x => x.Payment)
                .NotNull().WithMessage("Payment info is required.")
                .SetValidator(new PaymentCreateValidator());
        }
    }
}
