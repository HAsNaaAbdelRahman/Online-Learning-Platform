using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Core.Services.Contract
{
    public interface IInstructorServices<T> where T : class
    {
        Task<string> GetProgressInCourse(string UserId, string CourseId);
        Task<Module> AddModules(T AddModule);
        Task<Lesson> AddLessons(T AddLessonsDto);
        Task<Course> EditCourseDetails(string Id, T CourseDto);

    }
}
