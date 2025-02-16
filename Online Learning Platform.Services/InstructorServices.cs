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
    public class InstructorServices<T> : IInstructorServices<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public InstructorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> AddLessons(AddLessonsIntoModules AddLessonsDto)
        {
            Lesson lesson = new Lesson
            {
                Name = AddLessonsDto.Name,
                Description = AddLessonsDto.Description,
                ModuleId = AddLessonsDto.ModuleId,

            };
            await _context.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public Task<Lesson> AddLessons(T AddLessonsDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Module> AddModules(AddModulesInToCourse AddModule)
        {
            Module module = new Module
            {
                Name = AddModule.Name,
                Description = AddModule.Description,
                CourseId = AddModule.CourseId,

            };
            await _context.AddAsync(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public Task<Module> AddModules(T AddModule)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> EditCourseDetails(string Id, UpdateCourseDetails CourseDto)
        {
            var OldDetail = await _context.courses.FirstOrDefaultAsync(i => i.Id == Id);
        
            OldDetail.Description = CourseDto.Description;
            await _context.SaveChangesAsync();
            return OldDetail;
        }

        public Task<Course> EditCourseDetails(string Id, T CourseDto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetProgressInCourse(string UserId, string CourseId)
        {

            var IsFound = await _context
                .enrollments.SingleOrDefaultAsync(e => e.UserId == UserId && e.CourseId == CourseId);
            if (IsFound == null)
                return null;


            return IsFound.Status.ToString();        }
    }
}
