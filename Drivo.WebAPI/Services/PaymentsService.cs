using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class PaymentsService
{
    public PaymentsService(PaymentsRepository paymentsRepository, StudentsService studentsService)
    {
        PaymentsRepository = paymentsRepository;
        StudentsService = studentsService;
    }

    private PaymentsRepository PaymentsRepository { get; }
    private StudentsService StudentsService { get; }

    public async Task<List<PaymentEntity>> GetPaymentsAsync()
    {
        return await PaymentsRepository.GetPaymentsAsync();
    }

    public async Task<PaymentEntity> GetPaymentByIdAsync(int paymentId)
    {
        return await PaymentsRepository.GetPaymentByIdAsync(paymentId);
    }

    public async Task<ActionResponse> AddPaymentAsync(PaymentEntity payment)
    {
        return await PaymentsRepository.AddPaymentAsync(payment);
    }

    public async Task<ActionResponse> UpdatePaymentAsync(PaymentEntity payment)
    {
        return await PaymentsRepository.UpdatePaymentAsync(payment);
    }

    public async Task<ActionResponse> RemovePaymentAsync(int paymentId)
    {
        return await PaymentsRepository.RemovePaymentAsync(await GetPaymentByIdAsync(paymentId));
    }
}
