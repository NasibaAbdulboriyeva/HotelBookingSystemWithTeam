using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.RepositoryInterfaces
{
    public interface ICityRepository
    {
        Task<long> InsertAsync(City city);
        Task UpdateAsync(City city);
        Task RemoveAsync(long id);

        Task<City> SelectByIdAsync(long id);
        Task<ICollection<City>> SelectAllAsync();
        Task<ICollection<City>> SelectByCountryIdAsync(long countryId);

        Task<int> SaveChangesAsync(); 
    }
}
