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
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext appDbContext;
        public ReviewRepository(AppDbContext AppDbContext)
        {
            appDbContext = AppDbContext;
        }
        public async Task<long> InsertAsync(Review review)
        {
            appDbContext.Reviews.Add(review);
            await appDbContext.SaveChangesAsync();
            return review.ReviewId;
        }

        public async Task<ICollection<Review>> SelectByHotelIdAsync(long hotelId)
        {
            var exists = await appDbContext.Reviews.Where(r => r.HotelId == hotelId).ToListAsync();
            if (exists == null)
            {
                throw new KeyNotFoundException($"this {hotelId} not found");
            }
            return exists;
        }

        public async Task<Review> SelectByIdAsync(long id)
        {
            var review =  await appDbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (review == null)
            {
                throw new KeyNotFoundException($"this {id} not found");
            }
            return review;
        }

        public async Task<ICollection<Review>> SelectByUserIdAsync(long userId)
        {
            return await appDbContext.Reviews.Where(r => r.UserId == userId).ToListAsync();
        }
        public async Task<ICollection<Review>> SelectAllAsync()
        {
            return await appDbContext.Reviews.ToListAsync();
        }
    }
}
