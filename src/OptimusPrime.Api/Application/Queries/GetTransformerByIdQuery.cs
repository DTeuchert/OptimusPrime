using Mediator;
using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.Application.Queries;
public record GetTransformerByIdQuery(Guid Id) : IRequest<Transformer>;
