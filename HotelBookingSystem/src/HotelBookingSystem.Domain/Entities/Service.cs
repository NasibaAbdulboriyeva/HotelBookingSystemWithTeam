using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities;

public class Service
{
    public long ServiceId { get; set; }
    public string ServiceName  { get; set; }
    public string Description  { get; set; }
    public decimal Price  { get; set; }
    public bool IsAvailable { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; } = new Hotel();
}
