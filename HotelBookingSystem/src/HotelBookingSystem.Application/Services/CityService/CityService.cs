using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.CityDto;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.CityService;
using HotelBookingSystem.Core.Errors;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCityDto> _createCityValidator;

        public CityService(ICityRepository cityRepository, IMapper mapper, IValidator<CreateCityDto> createCityValidator)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _createCityValidator = createCityValidator;
        }

        public async Task<long> CreateAsync(CreateCityDto createCityDto)
        {
            ArgumentNullException.ThrowIfNull(createCityDto);

            var validationResult = await _createCityValidator.ValidateAsync(createCityDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var city = _mapper.Map<City>(createCityDto);
            await _cityRepository.InsertAsync(city);
            await _cityRepository.SaveChangesAsync();

            return city.CityId;
        }

        public async Task UpdateAsync(CityUpdateDto updateCityDto)
        {
            ArgumentNullException.ThrowIfNull(updateCityDto);

            var existing = await _cityRepository.SelectByIdAsync(updateCityDto.CityId);
            if (existing == null)
                throw new EntityNotFoundException("City not found.");

            _mapper.Map(updateCityDto, existing);
            await _cityRepository.UpdateAsync(existing);
            await _cityRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long cityId)
        {
            var city = await _cityRepository.SelectByIdAsync(cityId);
            if (city == null)
                throw new EntityNotFoundException("City not found.");

            await _cityRepository.RemoveAsync(cityId);
            await _cityRepository.SaveChangesAsync();
        }

        public async Task<CityDto> GetByIdAsync(long cityId)
        {
            var city = await _cityRepository.SelectByIdAsync(cityId);
            if (city == null)
                throw new EntityNotFoundException("City not found.");

            return _mapper.Map<CityDto>(city);
        }

        public async Task<ICollection<CityDto>> GetAllAsync()
        {
            var cities = await _cityRepository.SelectAllAsync();
            return cities.Select(_mapper.Map<CityDto>).ToList();
        }

        public async Task<ICollection<CityDto>> GetByCountryIdAsync(long countryId)
        {
            var cities = await _cityRepository.SelectByCountryIdAsync(countryId);
            return cities.Select(_mapper.Map<CityDto>).ToList();
        }
    }
}
