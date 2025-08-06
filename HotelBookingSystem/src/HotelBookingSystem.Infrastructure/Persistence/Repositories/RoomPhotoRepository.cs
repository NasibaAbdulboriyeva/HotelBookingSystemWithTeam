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
    public class RoomPhotoRepository : IRoomPhotoRepository
    {
        private readonly AppDbContext _context;

        public RoomPhotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsertAsync(RoomPhoto roomPhoto)
        {
            await _context.RoomPhotos.AddAsync(roomPhoto);
            return roomPhoto.RoomPhotoId;
        }

        public async Task UpdateAsync(RoomPhoto roomPhoto)
        {
            _context.RoomPhotos.Update(roomPhoto);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            var photo = await SelectByIdAsync(id);
            _context.RoomPhotos.Remove(photo);
        }

        public async Task<RoomPhoto> SelectByIdAsync(long id)
        {
            var photo = await _context.RoomPhotos.FirstOrDefaultAsync(p => p.RoomPhotoId == id);
            if (photo == null)
                throw new KeyNotFoundException($"RoomPhoto with ID {id} not found.");
            return photo;
        }

        public async Task<ICollection<RoomPhoto>> SelectAllAsync()
        {
            return await _context.RoomPhotos.ToListAsync();
        }

        public async Task<ICollection<RoomPhoto>> SelectByRoomIdAsync(long roomId)
        {
            return await _context.RoomPhotos
                .Where(p => p.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
