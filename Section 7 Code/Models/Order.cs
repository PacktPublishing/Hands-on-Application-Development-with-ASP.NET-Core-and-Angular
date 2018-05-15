using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPos.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public DateTime Time {get; set;}
    }
}