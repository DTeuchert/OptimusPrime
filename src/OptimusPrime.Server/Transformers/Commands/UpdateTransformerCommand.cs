using MediatR;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Transformers.Commands
{
    public class UpdateTransformerCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Alliance Alliance { get; set; }
        public int CategoryId { get; set; }
    }
}
