using Mediator;
using Microsoft.AspNetCore.Mvc;
using OptimusPrime.Api.Application.Commands;
using OptimusPrime.Api.Application.Queries;
using OptimusPrime.Api.ViewModels;
using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransformerController(IMediator mediator) : ControllerBase
{
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
    public async Task<ActionResult<TransformerViewModel>> Get(Guid id)
    {
        try
        {
            return Ok(await _mediator.Send(new GetTransformerByIdQuery(id)));
        }
        catch (Exception)
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
            var id = await _mediator.Send(new CreateTransformerCommand(
                new Transformer(Guid.NewGuid(), transformer.Name,
                    transformer.Allicance, new Category(transformer.Category.Id, transformer.Category.Name))));
            return CreatedAtAction(nameof(Get), new { id });
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(Guid id, [FromBody] TransformerViewModel transformer)
    {
        if (id != transformer.Id)
        {
            return BadRequest();
        }

        try
        {
            await _mediator.Send(new UpdateTransformerCommand(new Transformer(id, transformer.Name,
                transformer.Allicance, new Category(transformer.Category.Id, transformer.Category.Name))));
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteTransformerCommand(id));
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}
