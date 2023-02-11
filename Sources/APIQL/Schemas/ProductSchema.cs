using System;
using APIQL.Mutations;
using APIQL.Queries;
using GraphQL.Types;
using GraphQL;
using Schema = GraphQL.Types.Schema;

namespace APIQL.Schemas
{
	public class ProductSchema : Schema
    {
        public ProductSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<ProductQuery>();
            Mutation = provider.GetRequiredService<ProductMutation>();
        }
    }
}

