using Mediator;
using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.Application.Commands;
public record CreateTransformerCommand (Transformer Transformer) : IRequest<Guid>;
