using Microsoft.AspNetCore.Mvc;

namespace OptimusPrime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : Controller
    {
        // GET api/values
        [HttpGet]
        public bool Get()
        {
            return true;
        }
    }
}
