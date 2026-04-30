using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripManagementBL.Features.LocationTracking.Dtos
{
    public class CoordinatesDto
    {
        public DmsDto Latitude { get; set; }
        public DmsDto Longitude { get; set; }
    }

}
