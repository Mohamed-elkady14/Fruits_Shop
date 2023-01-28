using Fruits_Shop.Data;
using Fruits_Shop.Models;

namespace Fruits_Shop.Repository
{
    public class ProductRepository: IProductRepository
    {
        ShopDB DB;//= new ITIEntity();
        public ProductRepository(ShopDB DB)
        {
            this.DB = DB;
        }
        public List<Product> GetAll()
        {
            return DB.Products.ToList();
        }
        public Product GetByID(int id)
        {
            return DB.Products.FirstOrDefault(x => x.ID == id);

        }
        public void Insert(Product newProduct)
        {
            DB.Products.Add(newProduct);
            DB.SaveChanges();
        }
        public void Update(int id, Product newProduct)
        {
            //old refernce
            Product oldProduct = GetByID(id);
            //set new Values
            oldProduct.Name = newProduct.Name;
            oldProduct.Image=newProduct.Image;
            oldProduct.Price = newProduct.Price;
            oldProduct.DisCount = newProduct.DisCount;
                
            //save
            DB.SaveChanges();
        }
        public void Delete(int id)
        {
            //old refernce
            Product Prod = GetByID(id);
            DB.Products.Remove(Prod);
            DB.SaveChanges();
        }
    }
}
