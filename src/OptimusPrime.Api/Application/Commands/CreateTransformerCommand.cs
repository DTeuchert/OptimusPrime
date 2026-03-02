using MediatR;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Api.Application.Commands;
public record CreateTransformerCommand (Transformer Transformer) : IRequest<Guid>;
