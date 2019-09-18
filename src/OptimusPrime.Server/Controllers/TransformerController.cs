using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Server.Models;
using OptimusPrime.Server.Repositories;
using OptimusPrime.Server.ViewModels;

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
            return (await _transformerRepository.GetAsync())
                .Select(transformer => transformer.ToViewModel());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransformerViewModel>> Get(string id)
        {
            var transformer = await _transformerRepository.GetAsync(id);

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _transformerRepository.ExistsCategoryAsync(transformer.Category.Id))
            {
                return NotFound();
            }

            await _transformerRepository.AddAsync(new TransformerModel
            {
                Id = transformer.Id,
                Name = transformer.Name,
                Alliance = transformer.Allicance,
                Category = new CategoryModel
                {
                    Id = transformer.Category.Id
                }
            });
            return CreatedAtAction(nameof(Get), new { transformer.Id }, transformer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(string id, [FromBody] TransformerViewModel transformer)
        {
            if (id != transformer.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _transformerRepository.ExistsCategoryAsync(transformer.Category.Id))
            {
                return NotFound();
            }

            if (!await _transformerRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _transformerRepository.UpdateAsync(new TransformerModel
            {
                Id = transformer.Id,
                Name = transformer.Name,
                Alliance = transformer.Allicance,
                Category = new CategoryModel
                {
                    Id = transformer.Category.Id
                }
            });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var transformer = await _transformerRepository.GetAsync(id);
            if (transformer == null)
            {
                return NotFound();
            }

            await _transformerRepository.DeleteAsync(transformer.Id);
            return NoContent();
        }
    }
}
