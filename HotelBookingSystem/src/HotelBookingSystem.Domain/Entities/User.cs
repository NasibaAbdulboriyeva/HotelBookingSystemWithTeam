namespace HotelBookingSystem.Domain.Entities;

public class User
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string Salt { get; set; }
    public List<Card> Cards { get; set; }
    public List<Review> Reviews { get; set; }
}
