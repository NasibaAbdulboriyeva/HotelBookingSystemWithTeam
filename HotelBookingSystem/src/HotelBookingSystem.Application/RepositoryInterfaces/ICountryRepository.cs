using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.RepositoryInterfaces
{
    public interface ICountryRepository
    {
        Task<long> InsertAsync(Country country);
        Task UpdateAsync(Country country);
        Task RemoveAsync(long id);

        Task<Country> SelectByIdAsync(long id);
        Task<ICollection<Country>> SelectAllAsync();
        Task<Country?> SelectByCodeAsync(string code);

        Task<int> SaveChangesAsync();
    }
}
