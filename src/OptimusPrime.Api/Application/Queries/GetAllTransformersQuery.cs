using System.Collections.Generic;
using MediatR;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Api.Application.Queries;
public record GetAllTransformersQuery : IRequest<IEnumerable<TransformerViewModel>>;
