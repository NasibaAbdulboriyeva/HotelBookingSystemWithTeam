using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities;

public class Hotel
{
    public long HotelId { get; set; }
    public string HotelName { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public int TotalRooms { get; set; }
    public int StarRating{ get; set; }
    public List<Room> Rooms { get; set; } = new List<Room>();
}
