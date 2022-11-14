using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("Controller]")]
    public class ExternalExamsController : ControllerBase
    {
        public ExternalExamsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<ExternalExamEntity> GetExternalExam(int id)
        {
            return await Context.ExternalExams.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<ExternalExamEntity>> GetExternalExam()
        {
            return await Context.ExternalExams.ToListAsync();
        }

        [HttpPost]
        public async Task PostExternalExam(ExternalExamEntity externalExam)
        {
            await Context.ExternalExams.AddAsync(externalExam);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task PutExternalExam(ExternalExamEntity externalExam)
        {
            Context.ExternalExams.Update(externalExam);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteExternalExam(int id)
        {
            Context.ExternalExams.Remove(await Context.ExternalExams.FindAsync(id));
            await Context.SaveChangesAsync();
        }

    }
}
