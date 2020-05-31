using GraphQL.Types;
using OptimusPrime.Server.Models;

namespace OptimusPrime.Server.GraphQL.Types
{
    public class CategoryType : ObjectGraphType<CategoryModel>
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
