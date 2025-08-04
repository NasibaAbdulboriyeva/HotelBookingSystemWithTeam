using AutoMapper;
using FluentValidation;
using HotelBookingSystem.Application.Dtos.ServiceDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.AffairService;
using HotelBookingSystem.Domain.Entities;

public class AffairService : IAffairService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateServiceDto> _createServiceDtoValidator;

    public AffairService(IServiceRepository serviceRepository, IMapper mapper, IValidator<CreateServiceDto> createServiceDtoValidator)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _createServiceDtoValidator = createServiceDtoValidator;
    }

    public async Task<ServiceDto> GetByIdAsync(long id)
    {
        var service = await _serviceRepository.SelectByIdAsync(id);
        if (service == null)
            throw new InvalidOperationException($"Service with ID {id} not found.");

        return _mapper.Map<ServiceDto>(service);
    }

    public async Task<ICollection<ServiceDto>> GetByHotelIdAsync(long hotelId)
    {
        var services = await _serviceRepository.SelectByHotelIdAsync(hotelId);
        return services.Select(_mapper.Map<ServiceDto>).ToList();
    }

    public async Task<ICollection<ServiceDto>> GetAllAsync()
    {
        var services = await _serviceRepository.SelectAllAsync();
        return services.Select(_mapper.Map<ServiceDto>).ToList();
    }

    public async Task<long> CreateAsync(CreateServiceDto createServiceDto)
    {
        ArgumentNullException.ThrowIfNull(createServiceDto);

        var result = await _createServiceDtoValidator.ValidateAsync(createServiceDto);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var service = _mapper.Map<Service>(createServiceDto);
        await _serviceRepository.InsertAsync(service);
        await _serviceRepository.SaveChangesAsync(); // qo‘shildi
        return service.ServiceId;
    }

    public async Task UpdateAsync(ServiceUpdateDto updateServiceDto)
    {
        ArgumentNullException.ThrowIfNull(updateServiceDto);

        var existing = await _serviceRepository.SelectByIdAsync(updateServiceDto.ServiceId);
        if (existing == null)
            throw new InvalidOperationException("Service not found.");

        _mapper.Map(updateServiceDto, existing);
        await _serviceRepository.UpdateAsync(existing);
        await _serviceRepository.SaveChangesAsync(); // qo‘shildi
    }

    public async Task DeleteAsync(long id)
    {
        var existing = await _serviceRepository.SelectByIdAsync(id);
        if (existing == null)
            throw new InvalidOperationException("Service not found.");

        await _serviceRepository.RemoveAsync(id);
        await _serviceRepository.SaveChangesAsync(); // qo‘shildi
    }
}
