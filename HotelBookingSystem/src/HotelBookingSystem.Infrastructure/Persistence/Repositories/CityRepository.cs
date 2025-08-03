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
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> InsertAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            return city.CityId;
        }

        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
        }

        public async Task RemoveAsync(long id)
        {
            var city = await SelectByIdAsync(id);
            _context.Cities.Remove(city);
        }

        public async Task<City> SelectByIdAsync(long id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.CityId == id);
            if (city == null)
                throw new KeyNotFoundException($"City with ID {id} not found.");
            return city;
        }

        public async Task<ICollection<City>> SelectAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<ICollection<City>> SelectByCountryIdAsync(long countryId)
        {
            return await _context.Cities
                .Where(c => c.CountryId == countryId)
                .ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
