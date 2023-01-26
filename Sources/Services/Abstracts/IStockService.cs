using System;
using DTOs;

namespace Services.Abstracts
{
	public interface IStockService
	{

        IEnumerable<StockDTO> GetAll();
        StockDTO GetById(int id);
        void Create(StockDTO stock);
        void Update(StockDTO stock);
        void Delete(StockDTO stock);

    }
}

