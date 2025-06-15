using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Enums;

public enum ComplaintStatus
{
    Submitted = 0,     // Shikoyat yuborilgan
    InReview = 1,      // Ko‘rib chiqilmoqda
    Resolved = 2,      // Muammo hal qilingan
    Rejected = 3       // Shikoyat rad etilgan
}

