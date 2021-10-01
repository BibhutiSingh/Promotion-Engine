using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion_Engine.Core.BaseEngines;
using Promotion_Engine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion__Engine.Tests
{

    [TestClass()]
    public class CartTests
    {
        private Product ProductA = new Product() { Name = "A", UnitPrice = 50 };
        private Product ProductB = new Product() { Name = "B", UnitPrice = 20 };
        [TestMethod()]
        public void AddOrUpdateItemTest()
        {
            var cart = new Cart();
            cart.AddOrUpdateItem(ProductA, 5);
            cart.AddOrUpdateItem(ProductB, 3);

            cart.PerformCheckout(null);

            Assert.AreEqual(cart.Order.TotatQuantity, 8);

        }
        [TestMethod()]
        public void AddSameProductTest()
        {
            var cart = new Cart();
            cart.AddOrUpdateItem(ProductA, 5);
            cart.AddOrUpdateItem(ProductA, 3);

            cart.PerformCheckout(null);

            Assert.AreEqual(cart.Order.TotatQuantity, 3);

        }
    }
}