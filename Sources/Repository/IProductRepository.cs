using Models;

namespace Repository;
public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
    IEnumerable<Product> GetByName(string name);

}

