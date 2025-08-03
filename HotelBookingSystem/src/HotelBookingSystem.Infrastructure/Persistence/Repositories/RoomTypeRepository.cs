using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly AppDbContext _context;

        public RoomTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsertAsync(RoomType roomType)
        {
            await _context.RoomTypes.AddAsync(roomType);
            return roomType.RoomTypeId;
        }

        public async Task UpdateAsync(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
        }

        public async Task RemoveAsync(long id)
        {
            var roomType = await SelectByIdAsync(id);
            _context.RoomTypes.Remove(roomType);
        }

        public async Task<RoomType> SelectByIdAsync(long id)
        {
            var roomType = await _context.RoomTypes.FirstOrDefaultAsync(rt => rt.RoomTypeId == id);
            if (roomType == null)
                throw new KeyNotFoundException($"RoomType with ID {id} not found.");
            return roomType;
        }

        public async Task<ICollection<RoomType>> SelectAllAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType?> SelectByNameAsync(string name)
        {
            return await _context.RoomTypes
                .FirstOrDefaultAsync(rt => rt.Type.ToLower() == name.ToLower());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
