namespace DemoGraphQL.Server.GraphQL.GraphQLQueries
{
    using APIQL.Types;
    using DTOs;
    using global::GraphQL;
    using global::GraphQL.Types;
    using global::Repository;
    using Services;
    using Services.Abstracts;
    using System;
    using Types;

    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IProductService productService)
        {
            Field<ProductsType>(
               "createProduct",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
               resolve: context =>
               {
                   var item = context.GetArgument<ProductDTO>("product");
                   return productService.Create(item);
               }
           );


           

            Field<ProductsType>(
              "updateProduct",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" },
                  new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
              resolve: context =>
              {
                  var product = context.GetArgument<ProductDTO>("product");
                  var productId = context.GetArgument<int>("productId");

                  var dbProduct = productService.GetById(productId);
                  if (dbProduct == null)
                  {
                      context.Errors.Add(new ExecutionError("Couldn't find product in db."));
                      return null;
                  }
                  dbProduct.Name =  product.Name;
                  dbProduct.Price = product.Price;
                  dbProduct.Quantity = product.Quantity;
                  
                   productService.Update(dbProduct);
                  return product;
              }
          );


            Field<StringGraphType>(
                "deleteProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    var product = productService.GetById(productId);
                    if (product == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find product in db."));
                        return null;
                    }

                    productService.Delete(product);

                    return $"The product with the id: {productId} has been successfully deleted from db.";
                }
            );

        }
    }
}