using System.ComponentModel.DataAnnotations;

namespace FoodPos.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}