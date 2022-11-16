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
        public CourseModulsControllers(DatabaseContext context)
        {
            Context = context;
        }
        private DatabaseContext Context;

        [HttpGet("{id}")]
        public async Task<CourseModuleEntity> GetCourseModul(int id)
        {
            return await Context.CourseModules.FindAsync(id);
        }

        [HttpGet]
        public async Task<List<CourseModuleEntity>> GetCourseModuls()
        {
            return await Context.CourseModules.ToListAsync();
        }

        [HttpPost]
        public async Task PostCourseModul(CourseModuleEntity courseModul)
        {
            await Context.CourseModules.AddAsync(courseModul);
            await Context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task PutCourseModul(CourseModuleEntity courseModul)
        {
            Context.CourseModules.Update(courseModul);
            await Context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteCourseModul(int id)
        {
            Context.CourseModules.Remove(await Context.CourseModules.FindAsync(id));
            await Context.SaveChangesAsync();
        }
    }

}