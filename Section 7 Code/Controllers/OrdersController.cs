using System;
using FoodPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodPos.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly MyDbContext context;

        public OrdersController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var result = context.Orders
                            .Include(orders => orders.OrderItems)
                                .ThenInclude(a => a.Product)
                            .ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult SaveOrder([FromBody] FinalOrder finalOrder)
        {
            Order order = new Order();
            order.OrderItems = finalOrder.SelectedOrderItems;
            order.TotalPrice = finalOrder.TotalPrice;

            var d = DateTime.Now.ToString("yyyy-MM-dd");

            order.Time = DateTime.Parse(d);

            context.Orders.Add(order);
            var result = context.SaveChanges();

            return Accepted(result);
        }
    }
}

public class FinalOrder {
    public OrderItem[] SelectedOrderItems { get; set; }
    public decimal TotalPrice { get; set; }
}