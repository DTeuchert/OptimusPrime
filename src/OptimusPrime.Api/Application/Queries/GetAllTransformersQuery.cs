using Mediator;
using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.Application.Queries;
public record GetAllTransformersQuery : IRequest<IEnumerable<Transformer>>;
