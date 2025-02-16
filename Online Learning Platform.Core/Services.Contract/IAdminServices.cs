using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Online_Learning_Platform.Core.Services.Contract
{
    public interface IAdminServices <T> where T : class
    {

        Task<IEnumerable<T>> GetAllCoursesService();
        Task<IEnumerable<T>> GetCoursesByTypeService(string type);
        Task<T> AddCourseService(T courseDTO);
        Task<T> UpdateCourseService(string Id, T Updatedto);
        Task<T> DeleteOutDatedService(string Id);
    }
}
