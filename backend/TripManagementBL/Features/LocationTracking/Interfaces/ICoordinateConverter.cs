using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripManagementBL.Features.LocationTracking.Interfaces
{
    public interface ICoordinateConverter
    {
        double ConvertDMSToDecimal(string d, string m, string s);
    }
}
