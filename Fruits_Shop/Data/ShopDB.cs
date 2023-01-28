using Microsoft.EntityFrameworkCore;
using Fruits_Shop.Models;

namespace Fruits_Shop.Data
{
    public class ShopDB :DbContext
    {
        public ShopDB() : base()
        {

        }
       
        public ShopDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
   
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ShopDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
