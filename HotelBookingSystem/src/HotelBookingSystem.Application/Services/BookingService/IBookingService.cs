using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Services.BookingService
{
    public interface IBookingService
    {
        Task<long> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task UpdateBookingAsync(BookingDto updateBookingDto);
        Task DeleteBookingAsync(long bookingId);
        Task<BookingDto> GetByIdBookingAsync(long bookingID);
        Task<ICollection<BookingDto>> GetAllAsync();
        Task<ICollection<BookingDto>> GetActiveBookingsByUserIdAsync(long userId);
        Task<ICollection<BookingDto>> GetActiveBookingsByRoomIdAsync(long roomId);
        Task<ICollection<BookingDto>> GetByStatusAsync(BookingStatus status);
    }
}