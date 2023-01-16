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
	}
}

