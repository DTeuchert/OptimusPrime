using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Server.ViewModels;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Repositories;
using System.Linq;

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
        public async Task<IEnumerable<TransformerViewModel>> Get()
        {
            return (await _transformerRepository.GetAllAsync())
                .Select(transformer => transformer.ToViewModel());
        }

        // GET api/values/5
        [HttpGet("{guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransformerViewModel>> Get(string guid)
        {
            var transformer = await _transformerRepository.GetAsync(guid);

            if (transformer is null)
            {
                return NotFound();
            }
            return transformer.ToViewModel();
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransformerViewModel>> Create([FromBody] TransformerViewModel transformer)
        {
            if(! await _transformerRepository.ExistsCategoryAsync(transformer.Category.Id))
            {
                return NotFound();
            }

            await _transformerRepository.AddAsync(new Transformer
            {
                Guid = transformer.Guid,
                Name = transformer.Name,
                Alliance = transformer.Allicance,
                CategoryId = transformer.Category.Id
            });
            return CreatedAtAction(nameof(Get), new { transformer.Guid }, transformer);
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(string guid, [FromBody] TransformerViewModel transformer)
        {
            if (guid != transformer.Guid)
            {
                return BadRequest();
            }

            if (!await _transformerRepository.ExistsCategoryAsync(transformer.Category.Id))
            {
                return NotFound();
            }

            var transformerModel = await _transformerRepository.GetAsync(guid);
            if (transformerModel == null)
            {
                return NotFound();
            }

            await _transformerRepository.UpdateAsync(new Transformer
            {
                Guid = transformer.Guid,
                Name = transformer.Name,
                Alliance = transformer.Allicance,
                CategoryId = transformer.Category.Id
            });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
