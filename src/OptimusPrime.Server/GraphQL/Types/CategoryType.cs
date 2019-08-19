using GraphQL.Types;
using OptimusPrime.Server.Entities;

namespace OptimusPrime.Server.GraphQL.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.Id)
                .Description("Id of the category");
            Field(x => x.Name)
                .Description("Name of the category");
        }
    }
}
