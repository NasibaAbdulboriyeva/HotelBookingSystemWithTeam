using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.CountryDto;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.CountryService;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CountryCreateDto> _createCountryValidator;

        public CountryService(
            ICountryRepository countryRepository,
            IMapper mapper,
            IValidator<CountryCreateDto> createCountryValidator)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _createCountryValidator = createCountryValidator;
        }

        public async Task<long> CreateAsync(CountryCreateDto createCountryDto)
        {
            ArgumentNullException.ThrowIfNull(createCountryDto);

            var validationResult = await _createCountryValidator.ValidateAsync(createCountryDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existing = await _countryRepository.SelectByCodeAsync(createCountryDto.Code);
            if (existing != null)
                throw new InvalidOperationException("Country with this code already exists.");

            var country = _mapper.Map<Country>(createCountryDto);
            await _countryRepository.InsertAsync(country);
            await _countryRepository.SaveChangesAsync();
            return country.CountryId;
        }

        public async Task UpdateAsync(CountryUpdateDto updateCountryDto)
        {
            ArgumentNullException.ThrowIfNull(updateCountryDto);

            var existing = await _countryRepository.SelectByIdAsync(updateCountryDto.CountryId);
            if (existing == null)
                throw new KeyNotFoundException("Country not found.");

            _mapper.Map(updateCountryDto, existing);
            await _countryRepository.UpdateAsync(existing);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long countryId)
        {
            var existing = await _countryRepository.SelectByIdAsync(countryId);
            if (existing == null)
                throw new KeyNotFoundException("Country not found.");

            await _countryRepository.RemoveAsync(countryId);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task<CountryDto> GetByIdAsync(long countryId)
        {
            var country = await _countryRepository.SelectByIdAsync(countryId);
            if (country == null)
                throw new KeyNotFoundException("Country not found.");

            return _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> GetByCodeAsync(string code)
        {
            var country = await _countryRepository.SelectByCodeAsync(code);
            if (country == null)
                throw new KeyNotFoundException("Country not found.");

            return _mapper.Map<CountryDto>(country);
        }

        public async Task<ICollection<CountryDto>> GetAllAsync()
        {
            var countries = await _countryRepository.SelectAllAsync();
            return countries.Select(_mapper.Map<CountryDto>).ToList();
        }
    }
}
