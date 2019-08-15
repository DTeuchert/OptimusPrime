using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Repositories;

namespace OptimusPrime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformerController : Controller
    {
        private readonly ITransformerRepository _transformerRepository;

        public TransformerController(ITransformerRepository transformerRepository)
        {
            _transformerRepository = transformerRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Transformer>> Get()
        {
            return await _transformerRepository.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Transformer> Get(string guid)
        {
            return await _transformerRepository.GetAsync(guid);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
