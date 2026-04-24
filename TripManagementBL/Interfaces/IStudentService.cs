using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Dtos;

namespace TripManagementBL.Interfaces
{
    public interface IStudentService
    {
        Task CreateStudentAsync(CreateStudentDto dto);
        Task<StudentDto> GetStudentByStudentIdAsync(string studentId);
        Task<List<StudentDto>> GetAllStudentsAsync();
    }

}
