using HotelBookingSystem.Application.Dtos.RoomDtos;

namespace HotelBookingSystem.Application.Services.RoomServices
{
    public interface IRoomService
    {
        Task<RoomDto> GetRoomByIdAsync(long roomId);
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
        Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync();
        Task<long> CreateRoomAsync(CreateRoomDto newRoom);
        Task UpdateRoomAsync(long roomId, CreateRoomDto updatedRoom);
        Task DeleteRoomAsync(long roomId);
    }
}