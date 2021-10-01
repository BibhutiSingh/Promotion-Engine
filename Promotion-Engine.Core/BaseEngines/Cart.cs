using Promotion_Engine.Core.Entities;
using Promotion_Engine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_Engine.Core.BaseEngines
{
   
    public class Cart : ICheckout
    {
        public Order Order { get ; set ; }

        public Cart()
        {
            Order = new Order() { OrderDate = DateTime.Now, Status = OrderStatus.InCart };

        }


        public void AddOrUpdateItem(Product product, int quantity)
        {
            var orderItem = Order.OrderItems.FirstOrDefault(x => x.Product == product);
            if (orderItem is null)
            {
                orderItem = new OrderItem()
                {
                    Product = product,
                    Quantity = quantity,
                    Price = product.UnitPrice * quantity
                };
                Order.OrderItems.Add(orderItem);
            }
            else
            {
                orderItem.Quantity = quantity;
                orderItem.Price = product.UnitPrice * quantity;
            }
        }

        public decimal PerformCheckout(List<IPromotion> promotions)
        {
            if (promotions is not null)
            {
                foreach (var item in promotions)
                {
                    Order = item.ApplyPromotion(Order);
                }
            }
            
            Order.TotatQuantity = Order.OrderItems.Sum(x=>x.Quantity);
            return Order.TotalPrice = Order.OrderItems.Sum(x => x.FinalPrice);
        }

        public void RemoveItem(Product product)
        {
            var orderItem = Order.OrderItems.FirstOrDefault(x => x.Product == product);
            if (orderItem is not null)
            {
                Order.OrderItems.Remove(orderItem);
            }
        }

    }
}
