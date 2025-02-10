using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Core.Models;
using Online_Learning_Platform.DTO;
using Online_Learning_Platform.Repository.Data;

namespace Online_Learning_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Student")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
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
        [HttpGet("GetProgressInCourseById/{CourseId}")]
        public async Task<IActionResult> GetProgressInCourse([FromRoute] string CourseId)
        {
            var IsFound = await _context
                .enrollments.SingleOrDefaultAsync(e => e.CourseId == CourseId);
            if (IsFound == null)
                return NotFound($"No enrollment found CourseId = {CourseId}");

            return Ok(new { Status = IsFound.Status.ToString() });
        }

        [HttpPost("Enroll")]
        public async Task<IActionResult> Enroll([FromForm] EnrollmentRequest enrollment)
        {
            var existingEnrollment = await _context.enrollments
                    .FirstOrDefaultAsync(e => e.UserId == enrollment.UserId && e.CourseId == enrollment.CourseId);

            if (existingEnrollment != null)
                return BadRequest("Student is already enrolled in this course.");

            var userExists = await _context.Users.AnyAsync(u => u.Id == enrollment.UserId);
            var courseExists = await _context.courses.AnyAsync(c => c.Id == enrollment.CourseId);

            if (!userExists || !courseExists)
            {
                return BadRequest("Invalid UserId or CourseId.");
            }

            var Newenrollment = new Enrollment
            {
                UserId = enrollment.UserId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = DateTime.UtcNow,
                Status = Status.Active

            };
            await _context.enrollments.AddAsync(Newenrollment);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Enrollment successful!" });
        }
    }
}
