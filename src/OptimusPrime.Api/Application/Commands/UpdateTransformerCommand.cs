using MediatR;

namespace OptimusPrime.Api.Application.Commands;
public record UpdateTransformerCommand(Transformer Transformer) : IRequest;
