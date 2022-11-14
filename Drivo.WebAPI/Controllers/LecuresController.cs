using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class LecturesController : ControllerBase
    {
        public LecturesController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<LectureEntity> GetLecture(int id)
        {
            return await Context.Lectures.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<LectureEntity>> GetLectureList()
        {
            return await Context.Lectures.ToListAsync();
        }

        [HttpPost]
        public async Task PostLecture(LectureEntity lecture)
        {
            await Context.Lectures.AddAsync(lecture);
            await Context.SaveChangesAsync();   
        }
        [HttpPut]
        public async Task PutLecture(LectureEntity lecture)
        {
            Context.Lectures.Update(lecture);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteLecture(int id)
        {
            Context.Lectures.Remove(await Context.Lectures.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }
}
