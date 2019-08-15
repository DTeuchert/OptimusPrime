using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GraphQL.Types;
using OptimusPrime.Server.GraphQL.Types;
using OptimusPrime.Server.Repositories;

namespace OptimusPrime.Server.GraphQL
{
    public class TransformerQuery : ObjectGraphType
    {
        public TransformerQuery(ITransformerRepository transformerRepository)
        {
            Field<ListGraphType<TransformerType>>(
                "transformers",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType> { Name = "guid" },
                    new QueryArgument<StringGraphType> { Name = "name" }
                }),
                resolve: context =>
                {

                    var query = transformerRepository.GetQuery();
                    var user = (ClaimsPrincipal)context.UserContext;
                    var isUserAuthenticated = ((ClaimsIdentity)user.Identity).IsAuthenticated;

                    var transformerGuid = context.GetArgument<string>("guid");
                    if (!string.IsNullOrEmpty(transformerGuid))
                    {
                        return transformerRepository.GetQuery().Where(x => x.Guid == transformerGuid);
                    }

                    var transformerName = context.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(transformerName))
                    {
                        return transformerRepository.GetQuery().Where(x => x.Name == transformerName);
                    }

                    return query.ToList();
                }
            );
        }
    }
}
