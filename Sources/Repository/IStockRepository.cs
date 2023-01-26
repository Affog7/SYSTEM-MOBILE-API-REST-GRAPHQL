using System;
using Models;

namespace Repository
{
	public interface IStockRepository
	{
        IEnumerable<Stock> GetAll();
        Stock GetById(int id);
        void Create(Stock stock);
        void Update(Stock stock);
        void Delete(Stock stock);
    }
}

