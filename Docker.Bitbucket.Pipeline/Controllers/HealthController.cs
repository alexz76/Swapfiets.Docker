using Microsoft.AspNetCore.Mvc;

namespace Docker.Sample.Api.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet("api/health")]
        public IActionResult Get()
        {
            return Ok("All good!");
        }

        [HttpHead("api/health")]
        public IActionResult Head()
        {
            return Ok("All good too!");
        }
    }
}
