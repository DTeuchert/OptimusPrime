using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GraphQL.Types;
using OptimusPrime.Server.Entities;
using OptimusPrime.Server.GraphQL.Types;
using OptimusPrime.Server.Internal.Transformers;
using OptimusPrime.Server.Repositories;

namespace OptimusPrime.Server.GraphQL
{
    public class TransformerQuery : ObjectGraphType
    {
        /* --- Simple test query
         query TestQuery {
            transformers {
                guid, 
                name, 
                alliance, 
                category {
                    name
                }
            }
         }
         */

        public TransformerQuery(ITransformerRepository transformerRepository)
        {
            Field<ListGraphType<TransformerType>>(
                "transformers",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType> { Name = "guid" },
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<AllianceType> { Name = "alliance" }
                }),
                resolve: context =>
                {
                    var user = (ClaimsPrincipal)context.UserContext;
                    var isUserAuthenticated = ((ClaimsIdentity)user.Identity).IsAuthenticated;

                    var transformerGuid = context.GetArgument<string>("guid");
                    if (!string.IsNullOrEmpty(transformerGuid))
                    {
                        return transformerRepository.GetAsync(transformerGuid);
                    }

                    var transformerName = context.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(transformerName))
                    {
                        return transformerRepository.GetAsync(t => t.Name = transformerName);
                    }

                    var transformerAlliance = context.GetArgument<Alliance?>("alliance");
                    if (transformerAlliance != null)
                    {
                        return transformerRepository.GetAsync(t => t.Alliance = transformerAlliance);
                    }

                    return transformerRepository.GetAsync();
                }
            );
        }
    }
}
