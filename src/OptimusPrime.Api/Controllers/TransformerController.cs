using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Api.Application.Commands;
using OptimusPrime.Domain.Repositories;
using OptimusPrime.Server.Exceptions;
using OptimusPrime.Server.Repositories;
using OptimusPrime.Server.Transformers.Commands;
using OptimusPrime.Server.Transformers.Queries;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformerController(IMediator mediator, ITransformerRepository repository) : ControllerBase
    {
        private readonly ITransformerRepository _transformerRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        // GET api/transformers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransformerViewModel>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllTransformersQuery()));
        }

        // GET api/transformers/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransformerViewModel>> Get(string id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetTransformerQuery { Id = id }));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransformerViewModel>> Create([FromBody] TransformerViewModel transformer)
        {
            try
            {
                var id = await _mediator.Send(new CreateTransformerCommand
                {
                    Name = transformer.Name,
                    Alliance = transformer.Allicance,
                    CategoryId = transformer.Category?.Id ?? -1
                });
                return CreatedAtAction(nameof(Get), new { id });
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(string id, [FromBody] TransformerViewModel transformer)
        {
            if (id != transformer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(new UpdateTransformerCommand
                {
                    Id = transformer.Id,
                    Name = transformer.Name,
                    Alliance = transformer.Allicance,
                    CategoryId = transformer.Category?.Id ?? -1
                });
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _mediator.Send(new DeleteTransformerCommand { Id = id });
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
