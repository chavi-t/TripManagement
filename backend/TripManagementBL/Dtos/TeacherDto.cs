using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripManagementBL.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string TeacherId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int ClassId { get; set; }
    }
}
