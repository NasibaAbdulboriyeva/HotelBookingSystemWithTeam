namespace HotelBookingSystem.Application.Dtos.ServiceDtos;
public class ServiceDto
{
    public long ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public long HotelId { get; set; }
}
