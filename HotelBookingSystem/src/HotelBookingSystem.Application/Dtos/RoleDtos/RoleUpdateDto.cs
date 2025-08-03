using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.RoleDtos
{
    public class RoleUpdateDto
    {
        public long RoleId { get; set; }         // qaysi role-ni yangilash kerak
        public string RoleName { get; set; }     // rol nomi
        public string Description { get; set; }  // tavsif
        public bool IsActive { get; set; }
    }
}
