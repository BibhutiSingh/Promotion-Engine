using System;
using System.Collections.Generic;

namespace Promotion_Engine.Core.Entities
{
    public class OrderItem : EntityBase
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
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
                //Will be default for diffrent client
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int TotatQuantity { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        InCart,
        Completed
    }
}
