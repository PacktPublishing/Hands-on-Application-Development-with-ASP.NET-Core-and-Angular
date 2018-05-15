using System.ComponentModel.DataAnnotations;

namespace FoodPos.Models
{
    public class OrderItem
    {
        public int OrderItemId {get; set;}
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}