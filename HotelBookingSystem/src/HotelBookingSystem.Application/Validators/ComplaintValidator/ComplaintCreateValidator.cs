using FluentValidation;
using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.ComplaintValidator
{
    public class ComplaintCreateValidator : AbstractValidator<CreateComplaintDto>
    {
        public ComplaintCreateValidator()
        {
            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("HotelId must be greater than 0.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.")
                .MaximumLength(1000).WithMessage("Message must not exceed 1000 characters.");
        }
    }
}
