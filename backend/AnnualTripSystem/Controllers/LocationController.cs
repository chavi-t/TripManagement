using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TripManagementAPI.Hubs;
using TripManagementBL.Features.LocationTracking.Dtos;
using TripManagementBL.Features.LocationTracking.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IHubContext<LocationHub> _hubContext;

    public LocationController(
        ILocationService locationService,
        IHubContext<LocationHub> hubContext)
    {
        _locationService = locationService;
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> ReceiveLocation([FromBody] LocationDto dto)
    {
        try
        {
            var result = _locationService.ProcessLocation(dto);

            await _hubContext.Clients.All.SendAsync("ReceiveLocation", result);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}