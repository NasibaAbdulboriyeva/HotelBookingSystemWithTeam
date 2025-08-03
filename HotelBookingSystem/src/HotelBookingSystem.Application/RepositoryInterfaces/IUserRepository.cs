using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IUserRepository
{
    Task<User> SelectByIdAsync(long id);
    Task<User> SelectByEmailAsync(string email);
    Task<User> SelectUserByUserNameAsync(string userName);
    Task<ICollection<User>> SelectAllUsersAsync(int skip, int take);
    Task<long> InsertAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(long userId);
    Task<int> SaveChangesAsync();
}

