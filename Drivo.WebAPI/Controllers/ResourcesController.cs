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
    public class ResourcesControllers : ControllerBase
    {
        public ResourcesControllers(): base()
        {

        }
        public ResourcesControllers(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;

        [HttpGet("{id}")]
        public async Task<ResourceEntity> GetResource(int id)
        {
            return await Context.Resources.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<ResourceEntity>> GetResources()
        {
            return await Context.Resources.ToListAsync();
        }

        [HttpPost]
        public async Task PostResource(ResourceEntity resource)
        {
            await Context.Resources.AddAsync(resource);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task PutResource(ResourceEntity resource)
        {
            Context.Resources.Update(resource);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteResource(int id)
        {
            Context.Resources.Remove(await Context.Resources.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }

}