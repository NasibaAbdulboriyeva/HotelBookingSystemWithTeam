using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.ReviewDtos;
public class ReviewDto
{
    public long ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsVisible { get; set; }
    public long UserId { get; set; }

    public long HotelId { get; set; }
}
