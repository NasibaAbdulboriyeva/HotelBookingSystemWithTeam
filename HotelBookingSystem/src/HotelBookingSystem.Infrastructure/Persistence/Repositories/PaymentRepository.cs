using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Infrastructure.Persistence.Repositories;
public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment.PaymentId;
    }

    public async Task RemoveAsync(long paymentId)
    {
        var payment = await SelectByIdAsync(paymentId);
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Payment>> SelectByBookingIdAsync(long bookingId)
    {
        return await _context.Payments
            .Where(p => p.BookingId == bookingId)
            .ToListAsync();
    }

    public async Task<Payment> SelectByIdAsync(long paymentId)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        if (payment == null)
        {
            throw new KeyNotFoundException($"Payment with ID {paymentId} not found.");
        }
        return payment;
    }

    public async Task<ICollection<Payment>> SelectByStatusAsync(PaymentStatus status)
    {
        return await _context.Payments
            .Where(p => p.Status == status)
            .ToListAsync();
    }

    public async Task<ICollection<Payment>> SelectByUserIdAsync(long userId)
    {
        return await _context.Payments
            .Where(p => p.Booking.UserId == userId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }
    public async Task<ICollection<Payment>> SelectAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }
}
