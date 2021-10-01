using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion_Engine.Core.BaseEngines;
using Promotion_Engine.Core.Entities;
using Promotion_Engine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion__Engine.Tests
{
    [TestClass()]
    public class BuynItemsPromotionTests
    {
        private Product ProductA = new Product() { Name = "A", UnitPrice = 50 };
        private Product ProductB = new Product() { Name = "B", UnitPrice = 20 };
        [TestMethod("Buy N at X")]
        public void ApplyPromotionTest()
        {
            var cart = new Cart();
            cart.AddOrUpdateItem( ProductA,5 );
            cart.AddOrUpdateItem(ProductB, 3);

            var lst = new List<IPromotion>();
            lst.Add( new BuynItemsPromotion(ProductA, 3, 100));

            cart.PerformCheckout(lst);

            Assert.AreEqual(cart.Order.OrderItems[0].FinalPrice, 100);
        }
    }
}