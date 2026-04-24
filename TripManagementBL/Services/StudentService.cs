using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Dtos;
using TripManagementBL.Interfaces;
using TripManagementDAL.Models;

namespace TripManagementBL.Services
{
    public class StudentService : IStudentService
    {
        private readonly TripManagementDbContext _context;

        public StudentService(TripManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudentAsync(CreateStudentDto dto)
        {
            await ValidateStudentAsync(dto);

            var student = new Student
            {
                StudentId = dto.StudentId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ClassId = dto.ClassId
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentDto> GetStudentByStudentIdAsync(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
                throw new Exception("StudentId is required");

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (student == null)
                throw new Exception("Student not found");

            return new StudentDto
            {
                Id = student.Id,
                StudentId = student.StudentId,
                FullName = student.FirstName + " " + student.LastName,
                ClassId = student.ClassId
            };
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    StudentId = s.StudentId,
                    FullName = s.FirstName + " " + s.LastName,
                    ClassId = s.ClassId
                })
                .ToListAsync();

            return students;
        }

        private async Task ValidateStudentAsync(CreateStudentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.StudentId))
                throw new Exception("StudentId is required");

            if (await _context.Students.AnyAsync(s => s.StudentId == dto.StudentId))
                throw new Exception("Student already exists");

            if (!await _context.Classes.AnyAsync(c => c.Id == dto.ClassId))
                throw new Exception("Class not found");
        }
    }
}
