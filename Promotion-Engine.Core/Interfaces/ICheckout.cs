using Promotion_Engine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_Engine.Core.Interfaces
{
   public interface ICheckout
    {
        public Order Order { get; set; }
        void AddItem(Product product, int quantity);
        decimal PerformCheckout(List<PromotionItem> promotions);
    }
}
