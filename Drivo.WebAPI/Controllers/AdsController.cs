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
    public class AdsController : ControllerBase
    {
        public AdsController() : base()
        {

        }

        public AdsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;

        [HttpGet("{id}")]
        public async Task<AdEntity> GetAd(int id)
        {
            return await Context.Ads.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<AdEntity>> GetAds()
        {
            return await Context.Ads.ToListAsync();
        }

        [HttpPost]
        public async Task PostAd(AdEntity ad)
        {
            await Context.Ads.AddAsync(ad); 
            await Context.SaveChangesAsync();   
        }

        [HttpPut]
        public async Task PutAd(AdEntity ad)
        {
            Context.Ads.Update(ad);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAd(int id)
        {
            Context.Ads.Remove(await Context.Ads.FindAsync(id));
            await Context.SaveChangesAsync();   
        }
    }
}
