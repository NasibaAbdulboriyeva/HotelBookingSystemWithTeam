﻿using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IRoleRepository
{
    Task<long> InsertAsync(Role role);
    Task<Role> SelectByIdAsync(long roleId);
    Task<Role> SelectByNameAsync(string roleName);
    Task<ICollection<Role>> SelectAllAsync();
    Task UpdateAsync(Role role);
    Task RemoveAsync(long roleId);
    Task<int> SaveChangesAsync();
}
