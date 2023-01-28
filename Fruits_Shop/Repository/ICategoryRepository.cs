using Fruits_Shop.Models;

namespace Fruits_Shop.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Category> GetAllWithProductName();
        Category GetByID(int id);
        void Insert(Category newCategory);
        void Update(int id, Category newCategory);
        void Delete(int id);
    }
}
