using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TripManagementBL.Dtos;
using TripManagementBL.Interfaces;
using TripManagementDAL.Models;

namespace TripManagementBL.Services
{
    public class ClassService : IClassService
    {
        private readonly TripManagementDbContext _context;

        public ClassService(TripManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassDto>> GetAllClassesAsync()
        {
            return await _context.Classes
                .Select(c => new ClassDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
