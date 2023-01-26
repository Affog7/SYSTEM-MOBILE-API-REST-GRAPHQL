using System;
using AutoMapper;
using DTOs;
using Models;

namespace MONAPI.Mapper
{
	public class MyMapper : Profile
	{
		public MapperConfiguration ProductProfile()
		{
			return new MapperConfiguration(cf => { cf.CreateMap<ProductDTO, Product>().ReverseMap(); });

        }

        public MapperConfiguration StockProfile()
        {

            return new MapperConfiguration(cf => { cf.CreateMap<StockDTO, Stock>().ReverseMap(); });

        }

       public static Stock DtoToStock(StockDTO stock)
        {
            var m = new Stock
            {
                Id = stock.Id,
                Name = stock.Name,
                Products = stock.Products.Select(p => new Product { Id = p.Id, Name = p.Name, Price = p.Price, Quantity = p.Quantity }).ToList(),
            };
            return m;
        }


        public static StockDTO StockToDTO(Stock stck)
        {
            var  dto = new StockDTO
            {
                Id = stck.Id,
                Name = stck.Name,
                Products = stck.Products.Select(p => new ProductDTO { Id = p.Id, Name = p.Name, Price = p.Price, Quantity = p.Quantity }).ToList(),

            };
            return dto;
        }
    }
}

