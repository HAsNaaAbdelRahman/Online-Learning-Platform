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
    public class StudentServices<T> : IStudentServices<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public StudentServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Enrollment> Enroll(EnrollmentRequest enrollment)
        {
            var existingEnrollment = await _context.enrollments
.FirstOrDefaultAsync(e => e.UserId == enrollment.UserId && e.CourseId == enrollment.CourseId);
            var Newenrollment = new Enrollment
            {
                UserId = enrollment.UserId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = DateTime.UtcNow,
                Status = Status.Active

            };
            await _context.enrollments.AddAsync(Newenrollment);
            await _context.SaveChangesAsync();
            return Newenrollment;
        }

        public Task<Enrollment> Enroll(T enrollment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.courses
                           .Include(m => m.modules)
                            .ThenInclude(m => m.Lessons)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByType(string type)
        {
            return await _context.courses
                        .Where(i => i.Type.ToLower() == type.ToLower())
                        .ToListAsync();
        }

        public async Task<string> GetProgressInCourse(string CourseId)
        {
            var IsFound = await _context
                        .enrollments.FirstOrDefaultAsync(e => e.CourseId == CourseId);
            if (IsFound == null)
                return null;


            return IsFound.Status.ToString();
        }
    }
}
