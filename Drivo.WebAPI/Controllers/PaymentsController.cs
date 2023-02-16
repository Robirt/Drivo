using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PaymentsController : ControllerBase
{
    public PaymentsController(PaymentsService paymentsService)
    {
        PaymentsService = paymentsService;
    }

    private PaymentsService PaymentsService { get; }

    [HttpGet]
    [Authorize(Roles = "Administrator, Student")]
    public async Task<List<PaymentEntity>> GetPaymentsAsync()
    {
        if (User.IsInRole("Administrator")) return await PaymentsService.GetPaymentsAsync();

        return await PaymentsService.GetPaymentsByUserName(User.Identity.Name);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> AddPaymentAsync([FromBody] PaymentEntity payment)
    {
        var response = await PaymentsService.AddPaymentAsync(payment);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> UpdatePaymentAsync([FromBody] PaymentEntity payment)
    {
        var response = await PaymentsService.UpdatePaymentAsync(payment);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{paymentId}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> RemovePaymentAsync([FromRoute] int paymentId)
    {
        var response = await PaymentsService.RemovePaymentAsync(paymentId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}