namespace HotelBookingSystem.Domain.Entities;

public enum BookingStatus
{
    Pending = 0,      // Buyurtma berilgan, hali tasdiqlanmagan
    Confirmed = 1,    // Buyurtma tasdiqlangan
    Cancelled = 2,    // Buyurtma bekor qilingan
    CheckedIn = 3,    // Mijoz mehmonxonaga kirgan
    CheckedOut = 4    // Mijoz chiqib ketgan
}

