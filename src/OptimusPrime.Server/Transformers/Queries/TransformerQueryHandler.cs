using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OptimusPrime.Server.Exceptions;
using OptimusPrime.Server.Repositories;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Server.Transformers.Queries
{
    public class TransformerQueryHandler : IRequestHandler<GetTransformerQuery, TransformerViewModel>, 
        IRequestHandler<GetAllTransformersQuery, IEnumerable<TransformerViewModel>>
    {
        private readonly ITransformerRepository _transformerRepository;

        public TransformerQueryHandler(ITransformerRepository transformerRepository)
        {
            _transformerRepository = transformerRepository ?? throw new ArgumentNullException(nameof(transformerRepository));
        }

        public async Task<TransformerViewModel> Handle(GetTransformerQuery request, CancellationToken cancellationToken)
        {
            var transformer = await _transformerRepository.GetAsync(request.Id);

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
