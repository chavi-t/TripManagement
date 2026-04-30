using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Features.LocationTracking.Interfaces;

namespace TripManagementBL.Features.LocationTracking.Services
{
    public class CoordinateConverter: ICoordinateConverter
    {
        public double ConvertDMSToDecimal(string degrees, string minutes, string seconds)
        {
            double d = double.Parse(degrees);
            double m = double.Parse(minutes);
            double s = double.Parse(seconds);

            return d + (m / 60.0) + (s / 3600.0);
        }
    }
}
