using Online_Learning_Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public class StudentServices<T> : IStudentServices<T> where T : class
    {
        public T Enroll(EnrollmentRequest enrollment)
        {
            throw new NotImplementedException();
        }

        public T GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public T GetCoursesByType(string type)
        {
            throw new NotImplementedException();
        }

        public T GetProgressInCourse(string CourseId)
        {
            throw new NotImplementedException();
        }
    }
}
