using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities;

    public class RefreshToken
    {
        public long RefreshTokenId { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsRevoked { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }

