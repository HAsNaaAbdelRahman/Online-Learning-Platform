using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public interface IStudentServices<T> where T : class
    {
        T GetAllCourses();
        T GetCoursesByType(string type);
        T GetProgressInCourse(string CourseId);
        T Enroll(EnrollmentRequest enrollment);
    }
}
