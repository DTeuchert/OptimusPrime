using Mediator;
using OptimusPrime.Domain.Models;

namespace OptimusPrime.Api.Application.Commands;
public record UpdateTransformerCommand(Transformer Transformer) : IRequest;
