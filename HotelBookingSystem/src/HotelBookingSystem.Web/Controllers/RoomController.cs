using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Application.Services.CardServices;
using HotelBookingSystem.Application.Services.RoomServices;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Web.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService RoomService;

        public RoomController(IRoomService roomService)
        {
            RoomService = roomService;
        }

        [HttpPost("createRoom")]
        public Task<long> CreateRoomAsync(CreateRoomDto createRoomDto)
        {
            return RoomService.CreateRoomAsync(createRoomDto);
        }

        [HttpGet("getRoomById")]
        public async Task<RoomDto> GetRoomByIdAsync(long roomId)
        {
            return await RoomService.GetRoomByIdAsync(roomId);
        }

        [HttpGet("getAllRooms")]
        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            return await RoomService.GetAllRoomsAsync();
        }

        [HttpGet("getAvailableRooms")]
        public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync()
        {
            return await RoomService.GetAvailableRoomsAsync();
        }

        [HttpPut("updateRoom")]
        public async Task UpdateRoomAsync(long roomId, CreateRoomDto updatedRoom)
        {
            await RoomService.UpdateRoomAsync(roomId, updatedRoom);
        }

        [HttpDelete("deleteRoom")]
        public async Task DeleteRoomAsync(long roomId)
        {
            await RoomService.DeleteRoomAsync(roomId);
        }
    }
}
