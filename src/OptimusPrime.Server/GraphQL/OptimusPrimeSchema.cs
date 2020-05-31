using GraphQL;
using GraphQL.Types;

namespace OptimusPrime.Server.GraphQL
{
    public class OptimusPrimeSchema : Schema
    {
        public OptimusPrimeSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TransformerQuery>();
        }
    }
}
