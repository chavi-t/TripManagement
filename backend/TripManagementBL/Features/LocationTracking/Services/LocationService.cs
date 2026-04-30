using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripManagementBL.Features.LocationTracking.Dtos;
using TripManagementBL.Features.LocationTracking.Interfaces;

namespace TripManagementBL.Features.LocationTracking.Services
{
    
    using TripManagementBL.Features.LocationTracking.Dtos;
    using TripManagementBL.Features.LocationTracking.Interfaces;
    

    public class LocationService : ILocationService
    {
        private readonly ICoordinateConverter _coordinateConverter;

        public LocationService(ICoordinateConverter coordinateConverter)
        {
            _coordinateConverter = coordinateConverter;
        }

        public StudentLocationDto ProcessLocation(LocationDto dto)
        {
            Validate(dto);

            double lat = _coordinateConverter.ConvertDMSToDecimal(
                dto.Coordinates.Latitude.Degrees,
                dto.Coordinates.Latitude.Minutes,
                dto.Coordinates.Latitude.Seconds
            );

            double lng = _coordinateConverter.ConvertDMSToDecimal(
                dto.Coordinates.Longitude.Degrees,
                dto.Coordinates.Longitude.Minutes,
                dto.Coordinates.Longitude.Seconds
            );

            return new StudentLocationDto
            {
                Id = dto.ID,
                Lat = lat,
                Lng = lng
            };
        }

        private void Validate(LocationDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var coordinates = dto.Coordinates
                ?? throw new ArgumentException("Coordinates are missing");

            if (coordinates.Latitude == null || coordinates.Longitude == null)
                throw new ArgumentException("Latitude or Longitude missing");
        }
    }
}
