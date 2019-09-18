using System.Linq;

namespace OptimusPrime.Server.Internal
{
    public abstract class QueryBuilder<S, T>
    {
        public abstract IQueryable<S> Build(IQueryable<S> query, T options);
    }
}
