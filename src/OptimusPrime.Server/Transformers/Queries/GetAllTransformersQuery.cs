using System.Collections.Generic;
using MediatR;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Server.Transformers.Queries
{
    public class GetAllTransformersQuery : IRequest<IEnumerable<TransformerViewModel>>
    {
    }
}
