using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public interface IAdminServices <T> where T : class
    {
        
        T  GetAllCoursesService();
        T GetCoursesByTypeService(string type);
        T AddCourseService(AddNewCourse courseDTO);
        T GetAllStudentService();
        T UpdateCourseService(string Id, UpdateCourseInfoDto Updatedto);
        T DeleteOutDatedService(string Id);
    }
}
