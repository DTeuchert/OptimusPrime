using MediatR;

namespace OptimusPrime.Server.Transformers.Commands
{
    public class DeleteTransformerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
