using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.Exceptions;
using OptimusPrime.Server.Models;
using OptimusPrime.Server.Repositories;

namespace OptimusPrime.Server.Transformers.Commands
{
    public class TransformerCommandHandler : IRequestHandler<CreateTransformerCommand, string>,
        IRequestHandler<UpdateTransformerCommand>, IRequestHandler<DeleteTransformerCommand>
    {
        private readonly ITransformerRepository _transformerRepository;

        public TransformerCommandHandler(ITransformerRepository transformerRepository)
        {
            _transformerRepository = transformerRepository ?? throw new ArgumentNullException(nameof(transformerRepository));
        }

        public async Task<string> Handle(CreateTransformerCommand request, CancellationToken cancellationToken)
        {
            if (!await _transformerRepository.ExistsCategoryAsync(request.CategoryId))
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            return await _transformerRepository.AddAsync(new TransformerModel
            {
                Name = request.Name,
                Alliance = request.Alliance,
                Category = new CategoryModel
                {
                    Id = request.CategoryId
                }
            }, cancellationToken);
        }
        public async Task<Unit> Handle(UpdateTransformerCommand request, CancellationToken cancellationToken)
        {
            if (!await _transformerRepository.ExistsCategoryAsync(request.CategoryId))
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            if (await _transformerRepository.ExistsAsync(request.Id))
            {
                throw new NotFoundException(nameof(Transformer), request.Id);
            }

            await _transformerRepository.UpdateAsync(new TransformerModel
            {
                Id = request.Id,
                Name = request.Name,
                Alliance = request.Alliance,
                Category = new CategoryModel
                {
                    Id = request.CategoryId
                }
            }, cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteTransformerCommand request, CancellationToken cancellationToken)
        {

            var transformer = await _transformerRepository.GetAsync(request.Id);
            if (transformer is null)
            {
                throw new NotFoundException(nameof(Transformer), request.Id);
            }

            await _transformerRepository.DeleteAsync(transformer.Id, cancellationToken);

            return Unit.Value;
        }

    }
}
