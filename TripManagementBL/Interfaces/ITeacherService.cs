using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Dtos;

namespace TripManagementBL.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDto> CreateTeacherAsync(CreateTeacherDto dto);
        Task<TeacherDto> GetTeacherByTeacherIdAsync(string teacherId);
        Task<List<TeacherDto>> GetAllTeachersAsync();
        Task<List<StudentDto>> GetStudentsByTeacherAsync(string teacherId);
    }
}
