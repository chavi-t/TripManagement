using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripManagementBL.Features.LocationTracking.Dtos
{
    public class StudentLocationDto
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
