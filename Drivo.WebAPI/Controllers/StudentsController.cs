using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class StudentsController : ControllerBase
    {
        public StudentsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<StudentEntity> GetStudent(int id)
        {
            return await Context.Students.FindAsync(id);
        }

        [HttpPost]
        public async Task PostStudent(StudentEntity student)
        {
            await Context.Students.AddAsync(student);
            await Context.SaveChangesAsync();
        }
    }

}
