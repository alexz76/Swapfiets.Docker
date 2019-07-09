using Microsoft.AspNetCore.Mvc;

namespace Sonarqube.QualityGate.Sample.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet("api/health")]
        public IActionResult Get()
        {
            return Ok("All good!");
        }
    }
}
