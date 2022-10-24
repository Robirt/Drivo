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
    public class CourseModulsControllers : ControllerBase
    {
        public CourseModulsControllers() : base()
        {

        }
        public CourseModulsControllers(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;

        [HttpGet("{id}")]
        public async Task<CourseModulEntity> GetCourseModul(int id)
        {
            return await Context.CourseModuls.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<CourseModulEntity>> GetCourseModuls()
        {
            return await Context.CourseModuls.ToListAsync();
        }

        [HttpPost]
        public async Task PostCourseModul(CourseModulEntity courseModul)
        {
            await Context.CourseModuls.AddAsync(courseModul);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task PutCourseModul(CourseModulEntity courseModul)
        {
            Context.CourseModuls.Update(courseModul);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteCourseModul(int id)
        {
            Context.CourseModuls.Remove(await Context.CourseModuls.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }

}