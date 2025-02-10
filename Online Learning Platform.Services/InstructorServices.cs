using Online_Learning_Platform.DTO;
using Online_Learning_Platform.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public class InstructorServices<T> : IInstructorServices<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public InstructorServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public T AddLessons(AddLessonsIntoModules AddLessonsDto)
        {
            throw new NotImplementedException();
        }

        public T AddModules(AddModulesInToCourse AddModule)
        {
            throw new NotImplementedException();
        }

        public T EditCourseDetails(string Id, UpdateCourseDetails CourseDto)
        {
            throw new NotImplementedException();
        }

        public T GetAllStudentByCourseId(string Id)
        {
            throw new NotImplementedException();
        }

        public T GetProgressInCourse(string UserId, string CourseId)
        {
            throw new NotImplementedException();
        }
    }
}
