using Microsoft.AspNetCore.Mvc;
using PracticeSoftserve.Models;
using PracticeSoftserve.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeSoftserve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse([FromBody] Course course)
        {
            await _courseRepository.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            await _courseRepository.UpdateCourse(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _courseRepository.DeleteCourse(id);
            return NoContent();
        }
    }
}
