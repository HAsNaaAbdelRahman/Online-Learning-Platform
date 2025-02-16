using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;
using Online_Learning_Platform.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Learning_Platform.Core.Services.Contract;

namespace Online_Learning_Platform.Services
{
    public class AdminServices : IAdminServices<Course> 
    {
        protected readonly ApplicationDbContext _context;
        public AdminServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Course> AddCourseService(Course courseDTO)
        {
            await _context.AddAsync(courseDTO);
            return courseDTO;
        }

        public async Task<Course> DeleteOutDatedService(string Id)
        {
            var res = await _context.courses.FirstOrDefaultAsync(c => c.Id == Id);
            if (res != null)
                _context.courses.Remove(res);
            return res;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesService()
        {
            return await _context.courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByTypeService(string type)
        {
            return await _context.courses
                         .Where(i => i.Type.ToLower() == type.ToLower())
                         .ToListAsync();
        }

        public async Task<Course> UpdateCourseService(string Id, Course Updatedto)
        {
            var course = await _context.courses.FirstOrDefaultAsync(i => i.Id == Id);

            if (course != null)
            {
                course.Name = Updatedto.Name;
                course.Description = Updatedto.Description;
                course.Type = Updatedto.Type;
            }
            return course;
        }




    }
}
