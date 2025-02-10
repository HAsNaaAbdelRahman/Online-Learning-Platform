using Microsoft.AspNetCore.Mvc;
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
        T GetAllStudentByCourseId(string Id);
        T GetProgressInCourse(string UserId, string CourseId);
        T AddModules(AddModulesInToCourse AddModule);
        T AddLessons(AddLessonsIntoModules AddLessonsDto);
        T EditCourseDetails(string Id, UpdateCourseDetails CourseDto);

    }
}
