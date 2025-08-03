using HotelBookingSystem.Application.Dtos.RoomPhotoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Services.RoomPhotoService
{
    public interface IRoomPhotoService
    {
        Task<long> CreateAsync(CreateRoomPhotoDto createRoomPhotoDto);
        Task UpdateAsync(UpdateRoomPhotoDto roomPhotoUpdateDto);
        Task DeleteAsync(long roomPhotoId);

        Task<RoomPhotoDto> GetByIdAsync(long roomPhotoId);
        Task<ICollection<RoomPhotoDto>> GetAllAsync();
        Task<ICollection<RoomPhotoDto>> GetByRoomIdAsync(long roomId);
    }
}
