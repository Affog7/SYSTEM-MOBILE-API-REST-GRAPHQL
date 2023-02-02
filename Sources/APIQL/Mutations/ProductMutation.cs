using System;
using APIQL.Types;
using DTOs;
using GraphQL;
using GraphQL.Types;
using Repository;
using Services.Abstracts;

namespace APIQL.Mutations
{
	public class ProductMutation : ObjectGraphType
	{
        public ProductMutation(IProductService productService)
        {
            Field<ProductsType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductsType>> { Name = "guestInput" }
                ),
                resolve: context =>
                {
                    var item = context.GetArgument<ProductDTO>("guestInput");
                    return productService.Create(item);
                });
        }
    }
}

