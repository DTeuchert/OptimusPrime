using Mediator;

namespace OptimusPrime.Api.Application.Commands;
public record DeleteTransformerCommand(Guid Id) : IRequest;
