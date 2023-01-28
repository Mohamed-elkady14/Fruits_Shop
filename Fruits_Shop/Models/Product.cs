using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fruits_Shop.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public float Price { get; set; }
        public int? DisCount { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int Categ_Id { get; set; }
        public virtual Category? Category { get; set; }

    }
}
