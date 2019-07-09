using Microsoft.AspNetCore.Mvc;

namespace Docker.Sample.Api.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet("api/health")]
        public IActionResult Get()
        {
            return Ok("Welcome to Docker training!");
        }
    }
}
