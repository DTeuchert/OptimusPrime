using System.Linq;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.Internal.Transformers
{
    public class TransformerQueryBuilder : QueryBuilder<Transformer, TransformerQueryOption>
    {
        public override IQueryable<Transformer> Build(IQueryable<Transformer> query, TransformerQueryOption options)
        {
            if (!string.IsNullOrEmpty(options.Name))
            {
                query = query.Where(transformer => transformer.Name == options.Name);
            }

            if (options.Alliance != null)
            {
                query = query.Where(transformer => transformer.Alliance == options.Alliance);
            }

            if (options.CategoryId != null && options.CategoryId > 0)
            {
                query = query.Where(transformer => transformer.CategoryId == options.CategoryId);
            }

            return query;
        }
    }
}
