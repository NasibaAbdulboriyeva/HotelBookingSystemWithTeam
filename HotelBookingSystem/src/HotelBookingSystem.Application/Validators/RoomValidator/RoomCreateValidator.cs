using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.RoomValidator
{
    public class RoomCreateValidator : AbstractValidator<CreateRoomDto>
    {
        public RoomCreateValidator()
        {
            RuleFor(x => x.RoomNumber)
                .GreaterThan(0).WithMessage("Room number must be greater than 0.");

            RuleFor(x => x.RoomType)
                .NotEmpty().WithMessage("Room type is required.")
                .MaximumLength(100).WithMessage("Room type must not exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Hotel ID must be valid.");
        }
    }
}
