using FluentValidation;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.ReviewValidator
{
    public class ReviewCreateValidator : AbstractValidator<CreateReviewDto>
    {
        public ReviewCreateValidator()
        {
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(1000).WithMessage("Comment must not exceed 1000 characters.");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Hotel ID must be valid.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("User ID must be valid.");
        }
    }
}
