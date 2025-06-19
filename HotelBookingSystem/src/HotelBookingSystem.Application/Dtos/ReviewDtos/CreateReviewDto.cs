namespace HotelBookingSystem.Application.Dtos.ReviewDtos;
public class CreateReviewDto
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public long HotelId { get; set; }
}
