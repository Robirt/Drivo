using Drivo.Entities;
using Drivo.Responses;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class PaymentsService
{
    public PaymentsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<PaymentEntity>> GetPaymentsByStudentAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<PaymentEntity>>("/Payments");
    }

}
