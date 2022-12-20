using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class PaymentsRepository
{
    public PaymentsRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<PaymentEntity>> GetPaymentsByStudentAsync(StudentEntity student)
    {
        return await Context.Payments.Where(payment => payment.StudentId == student.Id).ToListAsync();
    }

    public async Task<PaymentEntity> GetPaymentByIdAsync(int paymentId)
    {
        return await Context.Payments.FirstOrDefaultAsync(payment => payment.Id == paymentId);
    }

    public async Task<ActionResponse> AddPaymentAsync(PaymentEntity payment)
    {
        try
        {
            await Context.Payments.AddAsync(payment);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Payment was added successfully.");
    }

    public async Task<ActionResponse> UpdatePaymentAsync(PaymentEntity payment)
    {
        try
        {
            Context.Payments.Update(payment);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Payment was updated successfully.");
    }

    public async Task<ActionResponse> RemovePaymentAsync(PaymentEntity payment)
    {
        try
        {
            Context.Payments.Remove(payment);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Payment was removed successfully.");
    }
}
