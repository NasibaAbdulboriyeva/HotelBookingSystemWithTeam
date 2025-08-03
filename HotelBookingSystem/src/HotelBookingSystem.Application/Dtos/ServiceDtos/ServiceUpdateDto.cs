using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.ServiceDtos
{
    public class ServiceUpdateDto
    {
        public long ServiceId { get; set; }         // qaysi service tahrir qilinmoqda
        public string ServiceName { get; set; }     // xizmat nomi (masalan: Wi-Fi, Pool)
        public string Description { get; set; }     // xizmat tavsifi
        public decimal Price { get; set; }          // narxi
        public bool IsAvailable { get; set; }
    }
}
