using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FoodPos.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Category, Price) VALUES ('Fried Egg', 'Breakfast', 2)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Category, Price) VALUES ('Bread', 'Breakfast', 1.5)");
            migrationBuilder.Sql("INSERT INTO Products(Name, Category, Price) VALUES ('Coffee', 'Hot Drink', 1.2)");

            migrationBuilder.Sql("INSERT INTO Orders(TotalPrice, Time) VALUES (11.70, '2017-12-23')");

            migrationBuilder.Sql("INSERT INTO OrderItems(OrderId, ProductId, Quantity) VALUES ((SELECT OrderId from Orders WHERE TotalPrice=11.70),(SELECT ProductId From Products WHERE Name='Bread'), 2)");
            migrationBuilder.Sql("INSERT INTO OrderItems(OrderId, ProductId, Quantity) VALUES ((SELECT OrderId from Orders WHERE TotalPrice=11.70),(SELECT ProductId From Products WHERE Name='Coffee'), 1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products WHERE Name='Bread'");
            migrationBuilder.Sql("DELETE FROM Products WHERE Name='Fried Egg'");
            migrationBuilder.Sql("DELETE FROM Products WHERE Name='Coffee'");

            migrationBuilder.Sql("DELETE FROM Orders WHERE TotalPrice=11.70");

            migrationBuilder.Sql("DELETE FROM OrderItems WHERE OrderId=(SELECT OrderId FROM Orders WHERE TotalPrice=11.70)");
        }
    }
}
