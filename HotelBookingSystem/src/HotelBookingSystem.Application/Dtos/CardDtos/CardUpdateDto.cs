using HotelBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Dtos.CardDtos
{
    public class CardUpdateDto
    {
        public long CardId { get; set; }             // kerak: qaysi kartani yangilash kerakligini aniqlash uchun
        public string CardHolderName { get; set; }   // foydalanuvchi o‘zgartirishi mumkin
        public int ExpiryMonth { get; set; }         // karta amal qilish oyini yangilash
        public int ExpiryYear { get; set; }          // yilni yangilash
        public CardType Type { get; set; }           // kartani turi (Visa, MasterCard)
        public bool SelectedForPayment { get; set; }
    }
}
