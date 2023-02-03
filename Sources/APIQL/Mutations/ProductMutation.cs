using System;
using APIQL.Types;
using DTOs;
using GraphQL;
using GraphQL.Types;
using NuGet.Protocol.Core.Types;
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
                       context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                       return null;
                   }

                   dbProduct.Name = product.Name;
                   dbProduct.Price = product.Price;
                   dbProduct.Quantity = product.Quantity;

                   productService.Update(dbProduct);

                   return dbProduct;
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

                    return $"The owner with the id: {productId} has been successfully deleted from db.";
                }
            );

        }
    }
}

