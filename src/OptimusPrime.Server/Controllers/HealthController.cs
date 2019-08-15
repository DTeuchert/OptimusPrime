using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Repositories;

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
