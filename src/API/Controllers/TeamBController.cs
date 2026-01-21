using Microsoft.AspNetCore.Mvc;

namespace BinaLite.Controllers
{
    [ApiController]
    [Route("api/teamb")]
    public class TeamBController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from TeamB API");
        }
    }
}
