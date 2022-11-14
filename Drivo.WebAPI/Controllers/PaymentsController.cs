using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drivo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class PaymentsControllers : ControllerBase
    {
        public PaymentsControllers(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;

        [HttpGet("{id}")]
        public async Task<PaymentEntity> GetPayment(int id)
        {
            return await Context.Payments.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<PaymentEntity>> GetPayments()
        {
            return await Context.Payments.ToListAsync();
        }

        [HttpPost]
        public async Task PostPayment(PaymentEntity payment)
        {
            await Context.Payments.AddAsync(payment);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task PutPayment(PaymentEntity payment)
        {
            Context.Payments.Update(payment);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeletePayment(int id)
        {
            Context.Payments.Remove(await Context.Payments.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }

}