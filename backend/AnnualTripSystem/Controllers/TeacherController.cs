using Microsoft.AspNetCore.Mvc;
using TripManagementBL.Interfaces;
using TripManagementBL.Dtos;

namespace TripManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDto dto)
        {
            try
            {
                var result = await _teacherService.CreateTeacherAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacher(string teacherId)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherByTeacherIdAsync(teacherId);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpGet("{teacherId}/students")]
        public async Task<IActionResult> GetStudentsByTeacher(string teacherId)
        {
            try
            {
                var students = await _teacherService.GetStudentsByTeacherAsync(teacherId);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
