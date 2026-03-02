using MediatR;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Api.Application.Queries;
public record GetTransformerByIdQuery(Guid Id) : IRequest<TransformerViewModel>;
