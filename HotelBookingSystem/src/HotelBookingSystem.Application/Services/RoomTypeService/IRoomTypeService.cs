using HotelBookingSystem.Application.Dtos.RoomTypeDto;
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.RoomTypeService
{
    public interface IRoomTypeService
    {
        Task<long> CreateAsync(CreateRoomTypeDto createRoomTypeDto);
        Task UpdateAsync(RoomTypeUpdateDto updateRoomTypeDto);
        Task DeleteAsync(long roomTypeId);

        Task<RoomTypeDto> GetByIdAsync(long roomTypeId);
        Task<RoomTypeDto> GetByNameAsync(string name);
        Task<ICollection<RoomTypeDto>> GetAllAsync();
    }
}
