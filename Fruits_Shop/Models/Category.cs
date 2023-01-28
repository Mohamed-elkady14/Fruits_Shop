namespace Fruits_Shop.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Categ_Name { get; set; }
        public string Categ_Image { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
