using Microsoft.AspNetCore.Mvc;
using PracticeSoftserve.Models;
using PracticeSoftserve.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PracticeSoftserve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher([FromBody] Teacher teacher)
        {
            await _teacherRepository.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }

            await _teacherRepository.UpdateTeacher(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            await _teacherRepository.DeleteTeacher(id);
            return NoContent();
        }
    }
}
