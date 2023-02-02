using System;
using APIQL.Types;
using GraphQL;
using GraphQL.Types;
using Repository;
using Services.Abstracts;

namespace APIQL.Queries
{
	public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productRepository)
        {
            Field<ListGraphType<ProductsType>>("",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IntGraphType>
                    {
                        Name = "Id"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "Name"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "Quantity"
                    },
                    new QueryArgument<DateTimeGraphType>
                    {
                        Name = "Price"
                    }
                }),
                resolve: context =>
                {
                    var query = productRepository.GetAll();

                    var guestId = context.GetArgument<int?>("id");
                    if (guestId.HasValue)
                    {
                        return query.Where(r => r.Id == guestId.Value);
                    }

                    var Name = context.GetArgument<string>("Name");
                    if (!string.IsNullOrEmpty(Name))
                    {
                        return query.Where(r => r.Name == Name);
                    }

                    var Price = context.GetArgument<double?>("Price");
                    if (Price.HasValue)
                    {
                        return query.Where(r => ((double)r.Price) == Price.Value);
                    }

                    var Quantity = context.GetArgument<int?>("Quantity");
                    if (Quantity.HasValue)
                    {
                        return query.Where(r => r.Quantity == Quantity.Value);
                    }

                    return query.ToList();
                }
            );
        }
    }
}

