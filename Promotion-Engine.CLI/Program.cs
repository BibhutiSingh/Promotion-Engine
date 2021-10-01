using Promotion_Engine.Core.BaseEngines;
using Promotion_Engine.Core.Entities;
using Promotion_Engine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Promotion_Engine.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Product productA = new Product() { Name = "A", UnitPrice = 50 };
            Product productB = new Product() { Name = "B", UnitPrice = 20 };
            Product productC = new Product() { Name = "C", UnitPrice = 100 };

            var lst = new List<IPromotion>();
            lst.Add( new BuynItemsPromotion(productA, 3, 100));
            lst.Add(new ComboPromotion(productB,productC, 100));

            Cart cart = new Cart();
            cart.AddOrUpdateItem(productA, 5);
            cart.AddOrUpdateItem(productB, 1);
            cart.AddOrUpdateItem(productC, 1);

            cart.PerformCheckout(lst);

            Console.WriteLine($"Item\t Quantity\t Price\t NetPrice");
            foreach (var item in cart.Order.OrderItems)
            {
                Console.WriteLine($"{item.Product.Name}\t \t {item.Quantity}\t {item.Price}\t {item.FinalPrice}");
                if (item.Discount is not null)
                {
                    Console.WriteLine($"Discount: {item.Discount.Name}");
                }
                
            }
            Console.WriteLine($"===================================");
            Console.WriteLine($" \t \t {cart.Order.TotatQuantity}\t {cart.Order.OrderItems.Sum(x=>x.Price)}\t {cart.Order.TotalPrice}");


        }
    }
}
