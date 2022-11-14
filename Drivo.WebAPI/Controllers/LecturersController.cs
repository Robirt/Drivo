using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class LecturersController : ControllerBase
    {
        public LecturersController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;
        

        [HttpGet("{id}")]
        public async Task<LecturerEntity> GetLecturer(int id)
        {
            return await Context.Lecturers.FindAsync(id);
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
        public async Task PostLecturer(LecturerEntity lecturer)
        {
            await Context.Lecturers.AddAsync(lecturer);
            await Context.SaveChangesAsync();
        }
    }

}
