using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers;

[ApiController]
[Route("/api")]
public class ApiController : ControllerBase
{

    private readonly ILogger<ApiController> _logger;

    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "/")]
    public IEnumerable<string> Get()
    {
        return new List<string>() {
        DateTime.Now.ToString("HH:mm:ss tt yyyy-MM-dd zzz"),
        Dns.GetHostName(),
        Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()
        };
    }
}
