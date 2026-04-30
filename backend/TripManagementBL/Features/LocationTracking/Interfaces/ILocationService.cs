using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Features.LocationTracking.Dtos;

namespace TripManagementBL.Features.LocationTracking.Interfaces
{
    public interface ILocationService
    {
        StudentLocationDto ProcessLocation(LocationDto dto);
    }
}
