using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities;

public class Complaint
{
    public long ComplaintId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public ComplaintStatus Status { get; set; }
}
