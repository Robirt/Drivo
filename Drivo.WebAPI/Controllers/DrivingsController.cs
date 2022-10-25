using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class DrivingsController : ControllerBase
    {
        public DrivingsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<DrivingEntity> GetDriving(int id)
        {
            return await Context.Drivings.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<DrivingEntity>> GetDrivingList()
        {
            return await Context.Drivings.ToListAsync();
        }

        [HttpPost]
        public async Task PostDriving(DrivingEntity driving)
        {
            await Context.Drivings.AddAsync(driving);
            await Context.SaveChangesAsync();   
        }
        [HttpPut]
        public async Task PutDriving(DrivingEntity driving)
        {
            Context.Drivings.Update(driving);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteDriving(int id)
        {
            Context.Drivings.Remove(await Context.Drivings.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }
}
