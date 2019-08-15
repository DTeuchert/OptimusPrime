using GraphQL.Types;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.GraphQL.Types
{
    public class TransformerType : ObjectGraphType<Transformer>
    {
        public TransformerType()
        {
            Field(x => x.Guid)
                .Description("Guid of the transformer");
            Field(x => x.Name)
                .Description("Name of the transformer");
        }
    }
}
