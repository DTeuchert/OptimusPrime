using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Repositories;

namespace OptimusPrime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformerController : ControllerBase
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
        [HttpGet("{guid}")]
        public async Task<ActionResult<Transformer>> Get(string guid)
        {
            var transformer = await _transformerRepository.GetAsync(guid);

            if (transformer is null)
            {
                return NotFound();
            }
            return transformer;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Transformer>> Create([FromBody] Transformer transformer)
        {
            await _transformerRepository.AddAsync(transformer);
            return CreatedAtAction(nameof(Get), new { transformer.Guid }, transformer);
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        public async Task<ActionResult> Update(string guid, [FromBody] Transformer transformer)
        {
            if (guid != transformer.Guid)
            {
                return BadRequest();
            }

            await _transformerRepository.UpdateAsync(transformer);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid)
        {
            var transformer = await _transformerRepository.GetAsync(guid);
            if (transformer == null)
            {
                return NotFound();
            }

            await _transformerRepository.DeleteAsync(transformer.Guid);
            return NoContent();
        }
    }
}
