using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public interface IStudentServices<T> where T : class
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<IEnumerable<Course>> GetCoursesByType(string type);
        Task<string> GetProgressInCourse(string CourseId);
        Task<Enrollment> Enroll(T enrollment);
    }
}
