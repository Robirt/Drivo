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
public class PaymentsControllers : ControllerBase
{
    public PaymentsControllers(PaymentsService paymentsService)
    {
        PaymentsService = paymentsService;
    }

    private PaymentsService PaymentsService { get; }

    [HttpGet("{studentUserName}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<List<PaymentEntity>>> GetPaymentsByStudentAsync([FromRoute] string studentUserName)
    {
        return Ok(await PaymentsService.GetPaymentsByStudentAsync(studentUserName));
    }

    [HttpGet]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<List<PaymentEntity>>> GetPaymentsByStudentAsync()
    {
        return Ok(await PaymentsService.GetPaymentsByStudentAsync(User.Identity.Name));
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