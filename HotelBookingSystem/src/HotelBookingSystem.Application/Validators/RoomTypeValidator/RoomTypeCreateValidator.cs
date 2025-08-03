using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoomTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.RoomTypeValidator
{
    public class RoomTypeCreateValidator : AbstractValidator<CreateRoomTypeDto>
    {
        public RoomTypeCreateValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Room type name is required.")
                .MaximumLength(100).WithMessage("Room type must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
    

}
