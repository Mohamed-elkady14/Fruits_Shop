using Fruits_Shop.Models;

namespace Fruits_Shop.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetByID(int id);
        void Insert(Product newProduct);
        void Update(int id, Product newProduct);
        void Delete(int id);
    }
}
