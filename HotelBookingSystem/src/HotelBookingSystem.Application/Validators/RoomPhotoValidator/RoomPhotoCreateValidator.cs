using FluentValidation;
using HotelBookingSystem.Application.Dtos.RoomPhotoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Validators.RoomPhotoValidator
{
    public class RoomPhotoCreateValidator : AbstractValidator<CreateRoomPhotoDto>
    {
        public RoomPhotoCreateValidator()
        {
            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("Room ID must be valid.");

            RuleFor(x => x.PhotoName)
                .NotEmpty().WithMessage("Photo name is required.")
                .MaximumLength(255).WithMessage("Photo name must not exceed 255 characters.");
        }
    }
}
