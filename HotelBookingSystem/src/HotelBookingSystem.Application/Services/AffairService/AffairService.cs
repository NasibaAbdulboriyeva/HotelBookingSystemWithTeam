using AutoMapper;
using HotelBookingSystem.Application.Dtos.ServiceDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Services.AffairService;

public class AffairService : IAffairService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public AffairService(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
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

    public async Task<long> CreateAsync(CreateServiceDto craeteServiceDto)
    {
        ArgumentNullException.ThrowIfNull(craeteServiceDto);

        var service = _mapper.Map<Service>(craeteServiceDto);
        return await _serviceRepository.InsertAsync(service);
    }

    public async Task UpdateAsync(ServiceDto updateServiceDto)
    {
        ArgumentNullException.ThrowIfNull(updateServiceDto);

        var existing = await _serviceRepository.SelectByIdAsync(updateServiceDto.ServiceId);
        if (existing == null)
            throw new InvalidOperationException("Service not found.");

        _mapper.Map(updateServiceDto, existing);

        await _serviceRepository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(long id)
    {
        var existing = await _serviceRepository.SelectByIdAsync(id);
        if (existing == null)
            throw new InvalidOperationException("Service not found.");

        await _serviceRepository.RemoveAsync(id);
    }
}
