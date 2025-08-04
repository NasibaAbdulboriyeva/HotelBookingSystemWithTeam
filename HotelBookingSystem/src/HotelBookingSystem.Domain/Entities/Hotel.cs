namespace HotelBookingSystem.Domain.Entities;

public class Hotel
{
    public long HotelId { get; set; }
    public string HotelName { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public int TotalRooms { get; set; }
    public int StarRating { get; set; }
    public City City { get; set; }
    public long  CityId { get; set; }
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Role> Roles { get; set; } = new List<Role>();
    public List<Service> Services { get; set; } = new List<Service>();
    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<Complaint> Complaints { get; set; } = new List<Complaint>();
}
