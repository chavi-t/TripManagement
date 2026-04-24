using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Dtos;
using TripManagementBL.Interfaces;
using TripManagementDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TripManagementBL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TripManagementDbContext _context;

        public TeacherService(TripManagementDbContext context)
        {
            _context = context;
        }

        public async Task<TeacherDto> CreateTeacherAsync(CreateTeacherDto dto)
        {
            await ValidateTeacherAsync(dto);

            var teacher = new Teacher
            {
                TeacherId = dto.TeacherId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ClassId = dto.ClassId
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return new TeacherDto
            {
                Id = teacher.Id,
                FullName = teacher.FirstName + " " + teacher.LastName,
                ClassId = teacher.ClassId
            };
        }

        public async Task<TeacherDto> GetTeacherByTeacherIdAsync(string teacherId)
        {
            if (string.IsNullOrWhiteSpace(teacherId))
                throw new Exception("TeacherId is required");

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (teacher == null)
                throw new Exception("Teacher not found");

            return new TeacherDto
            {
                Id = teacher.Id,
                TeacherId = teacher.TeacherId,
                FullName = teacher.FirstName + " " + teacher.LastName,
                ClassId = teacher.ClassId
            };
        }
        public async Task<List<TeacherDto>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers
                .Select(t => new TeacherDto
                {
                    Id = t.Id,
                    TeacherId = t.TeacherId,
                    FullName = t.FirstName + " " + t.LastName,
                    ClassId = t.ClassId
                })
                .ToListAsync();

            return teachers;
        }
        public async Task<List<StudentDto>> GetStudentsByTeacherAsync(string teacherId)
        {
            if (string.IsNullOrWhiteSpace(teacherId))
                throw new Exception("TeacherId is required");

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (teacher == null)
                throw new Exception("Teacher not found");

            var students = await _context.Students
                .Where(s => s.ClassId == teacher.ClassId)
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

        private async Task ValidateTeacherAsync(CreateTeacherDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TeacherId))
                throw new Exception("TeacherId is required");

            if (await _context.Teachers.AnyAsync(t => t.TeacherId == dto.TeacherId))
                throw new Exception("Teacher already exists");

            if (!await _context.Classes.AnyAsync(c => c.Id == dto.ClassId))
                throw new Exception("Class not found");
        }
    }
}