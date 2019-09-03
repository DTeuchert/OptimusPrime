using MediatR;
using OptimusPrime.Server.ViewModels;

namespace OptimusPrime.Server.Transformers.Queries
{
    public class GetTransformerQuery : IRequest<TransformerViewModel>
    {
        public string Id { get; set; }
    }
}
