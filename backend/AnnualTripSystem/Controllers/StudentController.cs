using Microsoft.AspNetCore.Mvc;
using TripManagementBL.Interfaces;
using TripManagementBL.Dtos;

namespace TripManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            try
            {
                var result = await _studentService.CreateStudentAsync(dto);

                return Ok(result);

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(string studentId)
        {
            try
            {
                var student = await _studentService.GetStudentByStudentIdAsync(studentId);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
    }
}