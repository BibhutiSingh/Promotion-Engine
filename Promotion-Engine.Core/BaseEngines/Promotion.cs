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
        public (decimal total, Order cart) ApplyPromotion(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
