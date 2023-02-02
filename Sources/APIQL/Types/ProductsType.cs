using System;
using DTOs;
using GraphQL.Types;

namespace APIQL.Types
{
	public class ProductsType  : ObjectGraphType<ProductDTO>
	{
		public ProductsType()
		{ 
                Field(x => x.Id);
                Field(x => x.Name);
                Field(x => x.Price);
                Field(x => x.Quantity); 
           
        }
	}
}

