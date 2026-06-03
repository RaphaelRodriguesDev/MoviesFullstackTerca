using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MoviesFullstackTerca.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheck : ControllerBase
{
    [HttpGet]
    public IActionResult Check()
    {
        return Ok("The API is working!");
    }
}
