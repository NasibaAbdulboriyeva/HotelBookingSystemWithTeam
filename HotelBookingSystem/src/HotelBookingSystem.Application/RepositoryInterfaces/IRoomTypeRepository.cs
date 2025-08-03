using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.RepositoryInterfaces
{
    public interface IRoomTypeRepository
    {
        Task<long> InsertAsync(RoomType roomType);
        Task UpdateAsync(RoomType roomType);
        Task RemoveAsync(long id);

        Task<RoomType> SelectByIdAsync(long id);
        Task<ICollection<RoomType>> SelectAllAsync();
        Task<RoomType?> SelectByNameAsync(string name);

        Task<int> SaveChangesAsync();
    }
}
