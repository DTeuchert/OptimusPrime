using Mediator;
using OptimusPrime.Domain.Models;
using OptimusPrime.Domain.Repositories;

namespace OptimusPrime.Api.Application.Queries;
public class TransformerQueryHandler(ITransformerRepository transformerRepository) :
    IRequestHandler<GetTransformerByIdQuery, Transformer>,
    IRequestHandler<GetAllTransformersQuery, IEnumerable<Transformer>>
{
    private readonly ITransformerRepository _transformerRepository = transformerRepository ?? throw new ArgumentNullException(nameof(transformerRepository));

    public async ValueTask<Transformer> Handle(GetTransformerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _transformerRepository.GetByIdAsync(request.Id, cancellationToken);
    }

    public async ValueTask<IEnumerable<Transformer>> Handle(GetAllTransformersQuery request, CancellationToken cancellationToken)
    {
        return await _transformerRepository.GetAllAsync(cancellationToken);
    }
}
