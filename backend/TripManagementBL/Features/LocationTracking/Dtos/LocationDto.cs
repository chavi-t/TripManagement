using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Dtos;

namespace TripManagementBL.Features.LocationTracking.Dtos
{
    public class LocationDto
    {
        public int ID { get; set; }
        public CoordinatesDto Coordinates { get; set; }
        public DateTime Time { get; set; }
    }
}
