using Microsoft.EntityFrameworkCore;
using Fruits_Shop.Data;
using Fruits_Shop.Models;

namespace Fruits_Shop.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        ShopDB DB;
        public CategoryRepository(ShopDB DB)
        {
            this.DB = DB;
        }
        public List<Category> GetAll()
        {
            return DB.Categories.ToList();
        }
        public List<Category> GetAllWithProductName()
        {
            return DB.Categories.Include(d => d.Products).ToList();
        }
        public Category GetByID(int id)
        {
            return DB.Categories.FirstOrDefault(x => x.ID == id);

        }
        public void Insert(Category newCategory)
        {
            DB.Categories.Add(newCategory);
            DB.SaveChanges();
        }
        public void Update(int id, Category newCategory)
        {
            //old refernce
            Category OldCategory = GetByID(id);
            //set new Values
            OldCategory.Categ_Name = newCategory.Categ_Name;
            OldCategory.Categ_Image = newCategory.Categ_Image;

            //save
            DB.SaveChanges();
        }
        public void Delete(int id)
        {
            Category categ = GetByID(id);
            DB.Categories.Remove(categ);
            DB.SaveChanges();
        }
    }
}
