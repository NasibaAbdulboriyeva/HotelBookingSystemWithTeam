﻿using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;

namespace HotelBookingSystem.Application.RepositoryInterfaces;
public interface IPaymentRepository
{
    Task<Payment> SelectByIdAsync(long paymentId);
    Task<ICollection<Payment>> SelectByBookingIdAsync(long bookingId);
    Task<ICollection<Payment>> SelectByUserIdAsync(long userId);
    Task<ICollection<Payment>> SelectByStatusAsync(PaymentStatus status);
    Task<ICollection<Payment>> SelectAllAsync();
    Task<long> InsertAsync(Payment payment);
    Task UpdateAsync(Payment payment);
    Task RemoveAsync(long paymentId);
    Task<int> SaveChangesAsync();
}

