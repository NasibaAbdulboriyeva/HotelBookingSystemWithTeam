using AutoMapper;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.Dtos.CardDtos;
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
            var convert = mapper.Map<Booking>(createBookingDto);
            var id = await bookingRepository.InsertAsync(convert);
            return id;
        }

        public async Task<ICollection<BookingDto>> GetActiveBookingsByRoomIdAsync(long roomId)
        {
            ArgumentNullException.ThrowIfNull(roomId);
            var booking = GetByIdBookingAsync(roomId);
            if(booking == null)
            {
                throw new EntityNotFoundException($"Booking not found");
            }    
            var bookings = await bookingRepository.SelectActiveBookingsByRoomIdAsync(roomId);
            List<BookingDto> result = new List<BookingDto>();
            foreach(var book in bookings)
            {
                result.Add(mapper.Map<BookingDto>(bookings));
            }
            return result;
        }

        public async Task<ICollection<BookingDto>> GetActiveBookingsByUserIdAsync(long userId)
        {
            var booking = GetByIdBookingAsync(userId);
            if (booking == null)
            {
                throw new EntityNotFoundException($"Booking not found");
            }
            var bookings = await bookingRepository.SelectActiveBookingsByUserIdAsync(userId);
            List<BookingDto> dto = new List<BookingDto>();
            foreach (var book in bookings)
            {
                dto.Add(mapper.Map<BookingDto>(bookings));
            }
            return dto;
        }

        public async Task<ICollection<BookingDto>> GetAllAsync()
        {
           var booking = await bookingRepository.SelectAllAsync();
           List<BookingDto> bookings = new List<BookingDto>();
            foreach( var book in booking)
            {
                bookings.Add(mapper.Map<BookingDto>(bookings));
            }
            return bookings;
        }

        public async Task<BookingDto> GetByIdBookingAsync(long bookingID)
        {
            var booking = await bookingRepository.SelectByIdAsync(bookingID);
            var convert = mapper.Map<BookingDto>(booking);
            return convert;
        }

        public async Task<ICollection<BookingDto>> GetByStatusAsync(BookingStatus status)
        {
            ArgumentNullException.ThrowIfNull(status);
            var booking = await bookingRepository.SelectByStatusAsync(status);
            var result = new List<BookingDto>();
            foreach(var book in booking)
            {
                result.Add(mapper.Map<BookingDto>(booking));
            }
            return result;
        }

        public async Task RemoveBookingAsync(long bookingID)
        {
            var booking = await bookingRepository.RemoveAsync(bookingID);
            if (booking == false)
            {
                throw new EntityNotFoundException($"Booking with that {bookingID} not found");
            }
        }

        public async Task UpdateBookingAsync(BookingDto updateBookingDto)
        {
            var convert = mapper.Map<Booking>(updateBookingDto);
             await bookingRepository.UpdateAsync(convert);
        }
    }
}
