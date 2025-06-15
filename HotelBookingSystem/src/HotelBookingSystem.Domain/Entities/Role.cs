using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Domain.Entities
{
    public class Role
    {
        public long RoleId  { get; set; }
        public string  RoleName { get; set; }
        public string  Description { get; set; }
        public bool IsActive { get; set; }
    }
}
