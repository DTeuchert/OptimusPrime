using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OptimusPrime.Api.Application.Queries;
using OptimusPrime.Api.ViewModels;
using OptimusPrime.Domain.Models;
using OptimusPrime.Domain.Repositories;
using OptimusPrime.Server.Exceptions;
using OptimusPrime.Server.Repositories;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Api.Application.Queries;
public class TransformerQueryHandler(ITransformerRepository transformerRepository) :
    IRequestHandler<GetTransformerByIdQuery, Transformer>,
    IRequestHandler<GetAllTransformersQuery, IEnumerable<Transformer>>
{
    private readonly ITransformerRepository _transformerRepository = transformerRepository ?? throw new ArgumentNullException(nameof(transformerRepository));

    public async Task<TransformerViewModel> Handle(GetTransformerByIdQuery request, CancellationToken cancellationToken)
    {
        var transformer = await _transformerRepository.GetAsync(request.Id, cancellationToken);

        if (transformer is null)
        {
            throw new NotFoundException(nameof(Transformers), request.Id);
        }
        return transformer.ToViewModel();
    }

    public async Task<IEnumerable<TransformerViewModel>> Handle(GetAllTransformersQuery request, CancellationToken cancellationToken)
    {
        return (await _transformerRepository.GetAllAsync())
            .Select(transformer => transformer.ToViewModel());
    }
}
}
