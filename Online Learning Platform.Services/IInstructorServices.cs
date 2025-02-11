using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public interface IInstructorServices<T> where T : class
    {
        //Task<User> GetAllStudentByCourseId(string Id);
        Task<string> GetProgressInCourse(string UserId, string CourseId);
        Task<Module> AddModules(AddModulesInToCourse AddModule);
        Task<Lesson> AddLessons(AddLessonsIntoModules AddLessonsDto);
        Task<Course> EditCourseDetails(string Id, UpdateCourseDetails CourseDto);

    }
}
