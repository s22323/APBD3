using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Exceptions;

namespace WebApplication1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IFileService fileService;

        public StudentsController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(FileService.students);
        }

        [HttpGet("{nrIndex}")]
        public async Task<IActionResult> GetStudentsByIndexNumber([FromRoute] string nrIndex)
        {
            Student student = null;
            try
            {
                student = fileService.GetStudentByIndexNr(nrIndex);
            } catch(StudentNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(Exception)
            {
                return BadRequest("Didn't manage to get student by index nr");
            }
            return Ok(student);
        }

        [HttpPut("{nrIndex}")]
        public async Task<IActionResult> UpdateStudentByIndexNumber([FromRoute] string nrIndex, [FromBody]Student student)
        {
            Student updatedStudent = null;
            try
            {
                updatedStudent = fileService.UpdateStudentByIndexNr(student, nrIndex);
            } catch(StudentNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(Exception)
            {
                return BadRequest("Didn't manage to update student");
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> addStudent([FromBody] Student student)
        {
           try
            {
                fileService.AddStudent(student);
            } catch (Exception e)
            {
                return BadRequest("Didn't manage to add student");
            }

            return Ok($"Student added");
        }

        [HttpDelete("{nrIndex}")]
        public async Task<IActionResult> removeStudentByIndexNumber([FromRoute] string nrIndex)
        {
            try
            {
                fileService.RemoveStudentByIndexNr(nrIndex);
            } catch(StudentNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(Exception)
            {
                return BadRequest("Didn't manage to remove student");
            }
            return Ok($"Student deleted");
        }

    }
}
