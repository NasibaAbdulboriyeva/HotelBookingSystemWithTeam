using AutoMapper;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;
        public BookingService(IBookingRepository Booking, IMapper Map)
        {
            bookingRepository = Booking;
            mapper = Map;
        }
        public async Task<long> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            ArgumentNullException.ThrowIfNull(createBookingDto);
            var bookingEntity = mapper.Map<Booking>(createBookingDto);

            return await bookingRepository.InsertAsync(bookingEntity);
        }

        public async Task<ICollection<BookingDto>> GetActiveBookingsByRoomIdAsync(long roomId)
        {
            ArgumentNullException.ThrowIfNull(roomId);           
            var bookings = await bookingRepository.SelectActiveBookingsByRoomIdAsync(roomId);

            return mapper.Map<ICollection<BookingDto>>(bookings);
        }

        public async Task<ICollection<BookingDto>> GetActiveBookingsByUserIdAsync(long userId)
        {
            var booking = bookingRepository.SelectByIdAsync(userId);         
            var bookings = await bookingRepository.SelectActiveBookingsByUserIdAsync(userId);

            return mapper.Map<ICollection<BookingDto>>(bookings);
        }

        public async Task<ICollection<BookingDto>> GetAllAsync()
        {
            var bookings = await bookingRepository.SelectAllAsync();            
            return mapper.Map<ICollection<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetByIdBookingAsync(long bookingID)
        {
            var booking = await bookingRepository.SelectByIdAsync(bookingID);
            var bookingDto = mapper.Map<BookingDto>(booking);

            return bookingDto;
        }

        public async Task<ICollection<BookingDto>> GetByStatusAsync(BookingStatus status)
        {
            ArgumentNullException.ThrowIfNull(status);
            var bookings = await bookingRepository.SelectByStatusAsync(status);

            return mapper.Map<ICollection<BookingDto>>(bookings);
        }

        public async Task DeleteBookingAsync(long bookingId)
        {
            var booking = await bookingRepository.SelectByIdAsync(bookingId);
            await bookingRepository.RemoveAsync(bookingId);
        }

        public async Task UpdateBookingAsync(BookingDto updateBookingDto)
        {
            var BookEntity = mapper.Map<Booking>(updateBookingDto);
            await bookingRepository.UpdateAsync(BookEntity);
        }
    }
}
