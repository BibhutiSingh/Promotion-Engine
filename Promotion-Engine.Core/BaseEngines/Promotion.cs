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


    public class ComboPromotion : IPromotion
    {
        private PromotionItem promotionItem;
        private Product Product2;
        private readonly decimal _finalPrice;
        public ComboPromotion(Product sku1, Product sku2, decimal fixedPrice)
        {
            promotionItem = new PromotionItem() { Name = $"Buy {sku1.Name} with {sku2.Name} at {fixedPrice}", MainProduct = sku1, };
            Product2 = sku2;
            _finalPrice = fixedPrice;

        }
        public Order ApplyPromotion(Order order)
        {
            var applicableItems = order.OrderItems.Where(x => x.Discount is null);

            var orderItem1 = applicableItems.FirstOrDefault(x => x.Product == promotionItem.MainProduct && x.Quantity==1);
            var orderItem2 = applicableItems.FirstOrDefault(x => x.Product == Product2 && x.Quantity==1);
            if (orderItem1 is not null && orderItem2 is not null)
            {
                var res = _finalPrice / 2;

                orderItem1.FinalPrice = res;
                orderItem1.Discount = promotionItem;

                orderItem2.FinalPrice = res;
                orderItem2.Discount = promotionItem;
            }
            return order;
        }
    }
}
