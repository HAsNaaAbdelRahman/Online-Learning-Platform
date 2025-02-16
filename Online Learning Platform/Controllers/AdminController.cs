using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.Core.Repositories.Contract;
using Online_Learning_Platform.DTO;
using Online_Learning_Platform.Repository.Data;
using System.Linq;

namespace Online_Learning_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ShowAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _context.courses
                .Include(m => m.modules)
                 .ThenInclude(m => m.Lessons)
                .ToListAsync();
            return Ok(courses);

        }

        [HttpGet("GetCoursesWithSpecificType/{type:alpha}")]
        public async Task<IActionResult> GetCoursesByType([FromRoute] string type)
        {

            var Courses = await _context.courses
                .Where(i => i.Type.ToLower() == type.ToLower())
                .ToListAsync();

            if (string.IsNullOrWhiteSpace(type))
            {
                return BadRequest("type cannot be empty.");
            }

            if (Courses == null || !Courses.Any())
                return NotFound($"Cannot find any courses within this {type}");

            return Ok(Courses);
        }

        [HttpPost("AddNewCourse")] 
        public async Task<IActionResult> AddCourse([FromForm] AddNewCourse courseDTO)
        {
            if (courseDTO == null)
                return BadRequest("Can not add an empty course's info");
            if(courseDTO.Name == null)
                return BadRequest("course's Name is Required");

            var course = new Course
            {
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                StartDate = courseDTO.StartDate,
                EndDate = courseDTO.EndDate,
                Type = courseDTO.Type,

            }; 
          await _context.AddAsync(course);
            _context.SaveChanges();


            return Ok(course);
        }
        [HttpPut("UpdateCourse/{Id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute]string Id,[FromForm] UpdateCourseInfoDto Updatedto)
        {
          
             var course = await _context.courses.FirstOrDefaultAsync(i => i.Id == Id);

            if (course == null)
                return NotFound("Cannot find course with this id");
            course.Name = Updatedto.Name;
             course.Description = Updatedto.Description;
             course.Type = Updatedto.Type;
                
            await _context.SaveChangesAsync(); 
            return Ok(course);
            

        }
        [HttpDelete("DeleteCourseById/{Id}")] 
        public async Task<IActionResult> DeleteOutDated([FromRoute] string Id)
        {
            var course = await _context.courses.FirstOrDefaultAsync(i => i.Id == Id);

            if (course == null)
                return NotFound("Cannot find course with this id");

            _context.Remove(course);
            await _context.SaveChangesAsync();
            return Ok(course);
        }


    }
}
