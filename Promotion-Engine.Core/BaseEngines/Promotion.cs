using Promotion_Engine.Core.Entities;
using Promotion_Engine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_Engine.Core.BaseEngines
{
    public class BuynItemsPromotion : IPromotion
    {
        private PromotionItem promotionItem;
        private readonly int _itemN;
        private readonly decimal _finalPrice;
        public BuynItemsPromotion(Product sku, int n, decimal fixedPrice)
        {
            promotionItem = new PromotionItem() { Name = $"Buy {n} at {fixedPrice}", MainProduct = sku };
            _itemN = n;
            _finalPrice = fixedPrice;

        }
        public Order ApplyPromotion(Order order)
        {
            var applicableItems = order.OrderItems.Where(x => x.Discount is null);

            var orderItem = applicableItems.FirstOrDefault(x => x.Product == promotionItem.MainProduct);
            if (orderItem is not null )
            {
                int appliedQuantity = (orderItem.Quantity / _itemN);
                int unappliedQuantity = (orderItem.Quantity % _itemN);
                orderItem.FinalPrice = (appliedQuantity * _finalPrice) + (unappliedQuantity * promotionItem.MainProduct.UnitPrice);

                orderItem.Discount = promotionItem;
            }
            return order;
        }
    }


    public class BuynComboPromotion : IPromotion
    {
        private PromotionItem promotionItem;
        private Product Product2;
        private readonly decimal _finalPrice;
        public BuynComboPromotion(Product sku1, Product sku2, decimal fixedPrice)
        {
            promotionItem = new PromotionItem() { Name = $"Buy {sku1.Name} with {sku2.Name} at {fixedPrice}", MainProduct = sku1, };
            Product2 = sku2;
            _finalPrice = fixedPrice;

        }
        public Order ApplyPromotion(Order order)
        {
            
        }
    }
}
