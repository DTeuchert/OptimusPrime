using GraphQL.Types;
using OptimusPrime.Server.Models;

namespace OptimusPrime.Server.GraphQL.Types
{
    public class TransformerType : ObjectGraphType<TransformerModel>
    {
        public TransformerType()
        {
            Field(x => x.Id);
            Field(x => x.Name)
                .Description("Name of the transformer");
            Field<AllianceType>(nameof(TransformerModel.Alliance));
            Field<CategoryType>(nameof(TransformerModel.Category));
        }
    }
}
