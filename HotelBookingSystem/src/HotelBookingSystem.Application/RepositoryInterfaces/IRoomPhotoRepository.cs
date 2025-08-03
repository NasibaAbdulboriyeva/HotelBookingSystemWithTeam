using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.RepositoryInterfaces
{
    public interface IRoomPhotoRepository
    {
        Task<long> InsertAsync(RoomPhoto roomPhoto);
        Task UpdateAsync(RoomPhoto roomPhoto);
        Task RemoveAsync(long id);

        Task<RoomPhoto> SelectByIdAsync(long id);
        Task<ICollection<RoomPhoto>> SelectAllAsync();
        Task<ICollection<RoomPhoto>> SelectByRoomIdAsync(long roomId);

        Task<int> SaveChangesAsync();
    }
}
