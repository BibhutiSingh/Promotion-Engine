using System;
using System.Collections.Generic;

namespace Promotion_Engine.Core.Entities
{
    public class OrderItem : EntityBase
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; set; }
        public PromotionItem Discount { get; set; }
    }
    public class Order: EntityBase
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int TotatQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }

        
    }
    public enum OrderStatus
    {
        InCart,
        Completed
    }
}
