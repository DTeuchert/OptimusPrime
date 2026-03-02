using MediatR;

namespace OptimusPrime.Api.Application.Commands
public record DeleteTransformerCommand(string Id) : IRequest;
