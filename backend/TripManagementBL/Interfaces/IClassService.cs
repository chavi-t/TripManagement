using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TripManagementBL.Dtos;

namespace TripManagementBL.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllClassesAsync();
    }
}
