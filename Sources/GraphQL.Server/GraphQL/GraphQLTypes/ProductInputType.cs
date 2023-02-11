using System;
using GraphQL.Types;

namespace APIQL.Types
{
	public class ProductInputType : InputObjectGraphType
	{
		public ProductInputType()
		{
            Name = "productInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<FloatGraphType>>("price");
            Field<NonNullGraphType<IntGraphType>>("quantity");
        }
	}
}

