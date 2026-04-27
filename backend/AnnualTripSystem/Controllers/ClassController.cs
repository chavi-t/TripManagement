using Microsoft.AspNetCore.Mvc;
using TripManagementBL.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClasses()
    {
        var classes = await _classService.GetAllClassesAsync();
        return Ok(classes);
    }
}