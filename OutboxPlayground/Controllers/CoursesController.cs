using Microsoft.AspNetCore.Mvc;
using Ordering.Data.Repositories.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ordering.Model.Entities;

namespace Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseRepository courseRepository) : ControllerBase
    {
        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await courseRepository.GetCoursesAsync(true);
            return Ok(courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await courseRepository.GetCourseByIdAsync(id, true);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            await courseRepository.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            await courseRepository.UpdateCourseAsync(course);
            return NoContent();
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            return await courseRepository.DeleteCourseAsync(id) ? NoContent() : NotFound();
        }
    }
}