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
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsertAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            return country.CountryId;
        }

        public async Task UpdateAsync(Country country)
        {
            _context.Countries.Update(country);
        }

        public async Task RemoveAsync(long id)
        {
            var country = await SelectByIdAsync(id);
            _context.Countries.Remove(country);
        }

        public async Task<Country> SelectByIdAsync(long id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
            if (country == null)
                throw new KeyNotFoundException($"Country with ID {id} not found.");
            return country;
        }

        public async Task<ICollection<Country>> SelectAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> SelectByCodeAsync(string code)
        {
            return await _context.Countries
                .FirstOrDefaultAsync(c => c.Code.ToLower() == code.ToLower());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
