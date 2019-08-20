using GraphQL.Types;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.GraphQL.Types
{
    public class AllianceType : EnumerationGraphType<Alliance>
    {
        public AllianceType()
        {
            Description = "Alliance of a Transformer.";
        }
    }
}
