using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class StudentsGroupController : ControllerBase
    {
        public StudentsGroupController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<StudentsGroupEntity> GetStudentsGroup(int id)
        {
            return await Context.StudentsGroup.FindAsync(id);
        }

        [HttpPost]
        public async Task PostStudentsGroups(StudentsGroupEntity studentsgroup)
        {
            await Context.StudentsGroup.AddAsync(studentsgroup);
            await Context.SaveChangesAsync();
        }
    }
}
