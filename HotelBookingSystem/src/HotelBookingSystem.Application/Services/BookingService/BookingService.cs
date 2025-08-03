using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.Dtos.ServiceDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateBookingDto> _createBookingDtoValidator;
        public BookingService(IBookingRepository Booking, IMapper Map, IValidator<CreateBookingDto> createBookingDtoValidator)
        {
            bookingRepository = Booking;
            mapper = Map;
           _createBookingDtoValidator = createBookingDtoValidator;
        }
        public async Task<long> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            ArgumentNullException.ThrowIfNull(createBookingDto);

            var validationResult = await _createBookingDtoValidator.ValidateAsync(createBookingDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var bookingEntity = mapper.Map<Booking>(createBookingDto);
            await bookingRepository.InsertAsync(bookingEntity);
            await bookingRepository.SaveChangesAsync();

            return bookingEntity.BookingId;
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
            await bookingRepository.SaveChangesAsync();

        }

        public async Task UpdateBookingAsync(BookingUpdateDto updateBookingDto)
        {
            var BookEntity = mapper.Map<Booking>(updateBookingDto);
            await bookingRepository.UpdateAsync(BookEntity);
            await bookingRepository.SaveChangesAsync();
        }
    }
}
