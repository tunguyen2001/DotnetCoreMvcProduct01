using System.ComponentModel.DataAnnotations;

namespace WebProduct1.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = string.Empty;

        public virtual List<Product> Products { get; set; }
    }
}
