using Microsoft.AspNetCore.Mvc;

namespace bindings.cron.Controllers;

[ApiController]
[Route("[controller]")]
public class DaprCronDemo : ControllerBase
{

    private readonly ILogger<DaprCronDemo> _logger;

    public DaprCronDemo(ILogger<DaprCronDemo> logger)
    {
        _logger = logger;
    }
    
    [HttpPost("/timer")]
    public IActionResult RunJob()
    {
        _logger.LogInformation("Dapr ile zamanlanmis gorev icin geldin :)");
        return Ok();
    }
    
}