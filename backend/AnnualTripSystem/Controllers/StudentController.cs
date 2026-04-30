using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TripManagementAPI.Hubs;
using TripManagementBL.Dtos;
using TripManagementBL.Interfaces;


namespace TripManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IHubContext<LocationHub> _hubContext;

       

        public StudentController(IStudentService studentService, IHubContext<LocationHub> hubContext)
        {
            _studentService = studentService;
            _hubContext = hubContext;

        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            try
            {
                var result = await _studentService.CreateStudentAsync(dto);
                

                    await _hubContext.Clients.All.SendAsync("NewStudent", result.StudentId);

                  

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