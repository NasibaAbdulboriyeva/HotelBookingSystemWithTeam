using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.Services.BookingService;
using HotelBookingSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{ 
        public class BookingController : ControllerBase
        {
            private readonly IBookingService bookingService;

            public BookingController(IBookingService BookingService)
            {
                bookingService = BookingService;
            }

            [HttpPost("create")]
            public Task<long> CreateBookingAsync(CreateBookingDto bookingDto)
            {
                return bookingService.CreateBookingAsync(bookingDto);
            }

            [HttpGet("getActiveBookingByRoomId")]
            public async Task<ICollection<BookingDto>> GetActiveBookingsByRoomIdAsync(long roomId)
            {
                return await bookingService.GetActiveBookingsByRoomIdAsync(roomId);
            }

            [HttpGet("GetActiveBookingsByUserId")]
            public async Task<ICollection<BookingDto>> GetActiveBookingsByUserIdAsync(long userId)
            {
                return await bookingService.GetActiveBookingsByUserIdAsync(userId);
            }

            [HttpGet("GetAll")]
            public async Task<ICollection<BookingDto>> GetAllAsync()
            {
                return await bookingService.GetAllAsync();
            }

            [HttpGet("GetByID")]
            public async Task<BookingDto> GetByIdBookingAsync(long bookingID)
            {
                return await bookingService.GetByIdBookingAsync(bookingID);
            }

            [HttpGet("GetByStatus")]
            public async Task<ICollection<BookingDto>> GetByStatusAsync(BookingStatus status)
            {
                return await bookingService.GetByStatusAsync(status);
            }


            [HttpDelete("DeleteBooking")]
            public async Task DeleteBookingAsync(long bookingId)
            {
                await bookingService.DeleteBookingAsync(bookingId);
            }

            [HttpDelete("GetAll")]
            public async Task UpdateBookingAsync(BookingDto updateBookingDto)
            {
                await bookingService.UpdateBookingAsync(updateBookingDto);
            }
        }
   
}
