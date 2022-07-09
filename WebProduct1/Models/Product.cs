using System.ComponentModel.DataAnnotations;

namespace WebProduct1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public int CategoriesId { get; set; }

        public virtual Category Category { get; set; }
    }
}
