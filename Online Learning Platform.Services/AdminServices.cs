﻿using Online_Learning_Platform.DTO;
using Online_Learning_Platform.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_Platform.Services
{
    public class AdminServices<T> : IAdminServices<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public AdminServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public T AddCourseService(AddNewCourse courseDTO)
        {
            throw new NotImplementedException();
        }

        public T DeleteOutDatedService(string Id)
        {
            throw new NotImplementedException();
        }

        public T GetAllCoursesService()
        {
            throw new NotImplementedException();
        }

        public T GetAllStudentService()
        {
            throw new NotImplementedException();
        }

        public T GetCoursesByTypeService(string type)
        {
            throw new NotImplementedException();
        }

        public T UpdateCourseService(string Id, UpdateCourseInfoDto Updatedto)
        {
            throw new NotImplementedException();
        }
    }
}
