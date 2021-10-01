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
    public class ComboPromotionTests
    {
        private Product ProductA = new Product() { Name = "A", UnitPrice = 50 };
        private Product ProductB = new Product() { Name = "B", UnitPrice = 20 };
        private Product ProductC = new Product() { Name = "C", UnitPrice = 100 };
        [TestMethod()]
        public void ApplyPromotionTest()
        {
            var cart = new Cart();
            cart.AddOrUpdateItem(ProductA, 1); //50
            cart.AddOrUpdateItem(ProductB, 1); //20
            cart.AddOrUpdateItem(ProductC, 1); //100

            var lst = new List<IPromotion>();
            lst.Add(new ComboPromotion(ProductA, ProductC, 100));

            cart.PerformCheckout(lst);

            Assert.AreEqual(cart.Order.OrderItems[0].FinalPrice, 50);
            Assert.AreEqual(cart.Order.OrderItems[1].FinalPrice, 20);
            Assert.AreEqual(cart.Order.OrderItems[2].FinalPrice, 50);
        }
    }
}