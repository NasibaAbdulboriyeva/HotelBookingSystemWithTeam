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

    public async Task<long> CreateAsync(CreateServiceDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var service = _mapper.Map<Service>(dto);
        return await _serviceRepository.InsertAsync(service);
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
        return services.Select(s => _mapper.Map<ServiceDto>(s)).ToList();
    }
}
