using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class InternalExamsController : ControllerBase
    {
        public InternalExamsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<InternalExamEntity> GetInternalExam(int id)
        {
            return await Context.InternalExams.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<InternalExamEntity>> GetInternalExam()
        {
            return await Context.InternalExams.ToListAsync();
        }

        [HttpPost]
        public async Task PostInternalExam(InternalExamEntity internalExam)
        {
            await Context.InternalExams.AddAsync(internalExam);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task PutInternalExam(InternalExamEntity internalExam)
        {
            Context.InternalExams.Update(internalExam);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteInternalExam(int id)
        {
            Context.InternalExams.Remove(await Context.InternalExams.FindAsync(id));
            await Context.SaveChangesAsync();
        }

    }
}
