using AutoMapper;
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
    //[Authorize(Roles = "Instructor")]

    public class InstructorController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public InstructorController(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAllStudentByCourseId/{Id}")]
        public async Task<IActionResult> GetAllStudentByCourseId([FromRoute] string Id)
        {
            var studentRoleId = await _context.Roles
                .Where(i => i.Name == "Student")
                .Select(i => i.Id)
                .FirstOrDefaultAsync();

            if (studentRoleId == null)
            {
                return NotFound("Student role not found");
            }

            var course = await _context.courses.FirstOrDefaultAsync(i => i.Id == Id);
            if (course == null)
            {
                return NotFound("Cannot find course with this id");
            }

            var studentsInCourse = await _context.enrollments
                .Where(e => e.CourseId == Id)
                .Join(_context.UserRoles,
                      e => e.UserId,
                      ur => ur.UserId,
                      (e, ur) => new { Enrollment = e, UserRole = ur })
                .Where(joined => joined.UserRole.RoleId == studentRoleId)
                .Join(_context.Users,
                      joined => joined.UserRole.UserId,
                      u => u.Id,
                      (joined, u) => u)
                .ToListAsync();

            return Ok(studentsInCourse);
        }

        [HttpGet("GetStudentWithProgress/{UserId}/{CourseId}")]
        public async Task<IActionResult> GetProgressInCourse([FromRoute] string UserId, [FromRoute] string CourseId)
        {
            var IsFound = await _context
                .enrollments.SingleOrDefaultAsync(e => e.UserId == UserId && e.CourseId == CourseId);
            if (IsFound == null)
                return NotFound($"No enrollment found for UserId = {UserId} and CourseId = {CourseId}");

            return Ok(new { Status = IsFound.Status.ToString() });
        }
        [HttpPost("AddModules")]
        public async Task <IActionResult> AddModules([FromForm]AddModulesInToCourse AddModule)
        {
            if (AddModule == null)
                return BadRequest("Can not add empty module in course.");
            var module = _mapper.Map<Module>(AddModule);
            await _context.AddAsync(module);
            await _context.SaveChangesAsync();
            return Ok(module);
        }
        [HttpPost("AddLessons")]
        public async Task<IActionResult> AddLessons([FromForm]AddLessonsIntoModules AddLessonsDto)
        {
            if (AddLessonsDto == null)
                return BadRequest("Can not add empty lesson in module.");
            var lesson = _mapper.Map<Lesson>(AddLessonsDto);
            await _context.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return Ok(lesson);
        }
        [HttpPut("EditCourseDetails/{Id}")]
        public async Task<IActionResult> EditCourseDetails([FromRoute]string Id,[FromForm]UpdateCourseDetails CourseDto)
        {
            var OldDetail = await _context.courses.FirstOrDefaultAsync(i => i.Id == Id);
            if(OldDetail == null)
            {
                return BadRequest($"Cannot find a course with this {Id}");
            }
            _mapper.Map(CourseDto, OldDetail);
            await _context.SaveChangesAsync();
            return Ok(OldDetail);
        }
    }
}
