using Mediator;
using OptimusPrime.Domain.Repositories;

namespace OptimusPrime.Api.Application.Commands;
public class TransformerCommandHandler(ITransformerRepository transformerRepository)
    : IRequestHandler<CreateTransformerCommand, Guid>,
        IRequestHandler<UpdateTransformerCommand>, IRequestHandler<DeleteTransformerCommand>
{
    private readonly ITransformerRepository _transformerRepository = transformerRepository ?? throw new ArgumentNullException(nameof(transformerRepository));

    public async ValueTask<Guid> Handle(CreateTransformerCommand request, CancellationToken cancellationToken)
    {
        return await _transformerRepository.AddAsync(request.Transformer, cancellationToken);
    }
    public async ValueTask<Unit> Handle(UpdateTransformerCommand request, CancellationToken cancellationToken)
    {

        await _transformerRepository.UpdateAsync(request.Transformer, cancellationToken);

        return Unit.Value;
    }

    public async ValueTask<Unit> Handle(DeleteTransformerCommand request, CancellationToken cancellationToken)
    {
        await _transformerRepository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}
