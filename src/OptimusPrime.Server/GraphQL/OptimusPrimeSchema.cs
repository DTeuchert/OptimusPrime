using GraphQL.Types;
using System;
using OptimusPrime.Server.Repositories;

namespace OptimusPrime.Server.GraphQL
{
    public class OptimusPrimeSchema : Schema
    {
        public OptimusPrimeSchema(ITransformerRepository transformerRepository, IServiceProvider provider) : base(provider)
        {
            Query = new TransformerQuery(transformerRepository);
        }
    }
}
