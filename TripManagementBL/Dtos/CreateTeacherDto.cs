using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripManagementBL.Dtos
{
    public class CreateTeacherDto
    {

        public string TeacherId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ClassId { get; set; }
        
    }
}
