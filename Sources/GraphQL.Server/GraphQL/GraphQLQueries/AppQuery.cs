namespace DemoGraphQL.Server.GraphQL.GraphQLQueries
{
    using global::GraphQL;
    using global::GraphQL.Types;
    using global::Repository;
    using Services.Abstracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;

    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IProductService productService)
        {
            // GET

            Field<ListGraphType<ProductsType>>(
              "products",
              resolve: context => productService.GetAll()
          );

            // GETBYID
            Field<ProductsType>(
             "product",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
             resolve: context =>
             {
                 int id;
                 if (!int.TryParse(context.GetArgument<string>("productId"), out id))
                 {
                     context.Errors.Add(new ExecutionError("Wrong value for id"));
                     return null;
                 }
                 return productService.GetById(id);
             }
         );

            // GETBYNAME

  
            Field<ListGraphType<ProductsType>>(
             "product_name",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "productName" }),
            resolve: context =>
            {
                var name = context.GetArgument<string>("productName");
                if (string.IsNullOrEmpty(name))
                {
                    context.Errors.Add(new ExecutionError("Invalid value for product name"));
                    return null;
                }
                return productService.GetByName(name);
            }
         );

        }
    }
}