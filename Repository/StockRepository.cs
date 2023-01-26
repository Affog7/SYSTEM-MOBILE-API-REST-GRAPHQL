using System;
using EF;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
	public class StockRepository : IStockRepository
	{
        private readonly MyDbContext _context;

        public StockRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Create(Stock stock)
        {
            _context.Stock.Add(stock);

        }

        public void Delete(Stock stock)
        {
            _context.Stock.Remove(stock);
        }

        public IEnumerable<Stock> GetAll()
        {
            return _context.Stock
                .Include(a => a.Products)
                .Select(a => new Stock
                {
                    Id = a.Id,
                    Name = a.Name,
                    Products = a.Products.Select(p => new Product { Id = p.Id, Name = p.Name, Price = p.Price, Quantity = p.Quantity }).ToList()
                })
                .ToList();
        }

        public Stock GetById(int id)
        {
          return _context.Stock
            .Include(p => p.Products)
            .Select(a => new Stock
            {
                Id = a.Id,
                Name = a.Name,
                Products = a.Products.Select(p => new Product { Id = p.Id, Name = p.Name, Price = p.Price, Quantity = p.Quantity }).ToList()
            })
            .FirstOrDefault(p => p.Id == id); 

        }

        public void Update(Stock stock)
        {
            _context.Stock.Update(stock);
        }
    }
}

