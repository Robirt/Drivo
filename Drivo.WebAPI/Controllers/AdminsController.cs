using Drivo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class AdminsController : ControllerBase
    {
        public AdminsController(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;


        [HttpGet("{id}")]
        public async Task<AdminEntity> GetAdmin(int id)
        {
            return await Context.Admins.FindAsync(id);
        }
        [HttpGet]
        public async Task<List<StudentEntity>> GetStudents()
        {
            return await Context.Students.ToListAsync();
        }

        [HttpGet]
        public async Task<List<InstructorEntity>> GetInstructors()
        {
            return await Context.Instructors.ToListAsync();
        }

        [HttpGet]
        public async Task<List<LecturerEntity>> GetLecturers()
        {
            return await Context.Lecturers.ToListAsync();
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


        [HttpGet("SearchLecturersByFirstname/{firstname}")]
        public async Task<List<LecturerEntity>> GetLecturersByFirstname(string firstname)
        {
            return await Context.Lecturers.Where(lecturer => lecturer.Firstname.StartsWith(firstname)).ToListAsync();
        }
    

        [HttpGet("SearchLecturersBySurname/{surname}")]
        public async Task<List<LecturerEntity>> GetLecturersBySurname(string surname)
        {
            return await Context.Lecturers.Where(lecturer => lecturer.Surname.StartsWith(surname)).ToListAsync();
        }

        [HttpGet("SearchLecturersByFullName/{name}")]
        public async Task<List<LecturerEntity>> GetLecturersByFullName(string name)
        {
            return await Context.Lecturers.Where(lecturer => lecturer.Firstname.Contains(name) || lecturer.Surname.Contains(name)).ToListAsync();
        }

        [HttpGet("SearchInstructorsByFirstName/{firstname}")]
        public async Task<List<InstructorEntity>> GetInstructorsByFirstname(string firstname)
        {
            return await Context.Instructors.Where(instructor => instructor.Firstname.StartsWith(firstname)).ToListAsync();
        }
    

        [HttpGet("SearchInstructorsBySurname/{surname}")]
        public async Task<List<InstructorEntity>> GetInstructorsBySurname(string surname)
        {
            return await Context.Instructors.Where(instructor => instructor.Surname.StartsWith(surname)).ToListAsync();
        }

        [HttpGet("SearchInstructorsByFullName/{name}")]
        public async Task<List<InstructorEntity>> GetInstructorsByFullName(string name)
        {
            return await Context.Instructors.Where(instructor => instructor.Firstname.Contains(name) || instructor.Surname.Contains(name)).ToListAsync();
        }


        [HttpPost]
        public async Task PostAdmin(AdminEntity admin)
        {
            await Context.Admins.AddAsync(admin);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteStudent(int id)
        {
            Context.Students.Remove(await Context.Students.FindAsync(id));
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteLecturer(int id)
        {
            Context.Lecturers.Remove(await Context.Lecturers.FindAsync(id));
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteInstructor(int id)
        {
            Context.Instructors.Remove(await Context.Instructors.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }

}
