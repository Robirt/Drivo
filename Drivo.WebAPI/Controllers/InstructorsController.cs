using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class InstructorsController : ControllerBase
    {
        public InstructorsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;
        

        [HttpGet("{id}")]
        public async Task<InstructorEntity> GetInstructor(int id)
        {
            return await Context.Instructors.FindAsync(id);
        }


        [HttpGet("SearchStudentsByFirstname/{firstname}")]
        public async Task<List<StudentEntity>> GetStudentsByFirstname(string firstname)
        {
            return await Context.Students.Where(student => student.Firstname.StartsWith(firstname)).ToListAsync();
        }

        [HttpGet("SearchStudentsBySurname/{surname}")]
        public async Task<List<StudentEntity>> GetStudentBySurname(string surname)
        {
            return await Context.Students.Where(student => student.Surname.StartsWith(surname)).ToListAsync();
        }

        [HttpGet("SearchStudentsByFullName/{name}")]
        public async Task<List<StudentEntity>> GetStudentsByFullName(string name)
        {
            return await Context.Students.Where(student => student.Firstname.Contains(name) || student.Surname.Contains(name)).ToListAsync();
        }


        [HttpPost]
        public async Task PostInstructor(InstructorEntity instructor)
        {
            await Context.Instructors.AddAsync(instructor);
            await Context.SaveChangesAsync();
        }
    }

}
