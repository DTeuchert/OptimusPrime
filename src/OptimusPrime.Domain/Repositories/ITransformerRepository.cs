using OptimusPrime.Domain.Abstractions;
using OptimusPrime.Domain.Models;

namespace OptimusPrime.Domain.Repositories;
public interface ITransformerRepository : IRepository<Transformer, Guid>
{
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<Transformer>> GetAllAsync(CancellationToken cancellationToken =  default);
}
