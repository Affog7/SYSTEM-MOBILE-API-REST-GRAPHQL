using System;
using System.Linq;
using EF;
using Models;

namespace Repository
{
	public class ProductRepository:IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList<Product>();
        }

        public Product GetById(int id)
        {
            return _context.Product.Find(id);
        }

        public void Create(Product product)
        {
            _context.Product.Add(product);
        }

        public void Update(Product product)
        {
            _context.Product.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Product.Remove(product);
        }
    }
}

