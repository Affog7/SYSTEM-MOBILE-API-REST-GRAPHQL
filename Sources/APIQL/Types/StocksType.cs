using System;
using DTOs;
using GraphQL.Types;

namespace APIQL.Types
{
	public class StocksType : ObjectGraphType<StockDTO>
    {
		public StocksType()
		{
			Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Products);
        }
	}
}

