using ComputersTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Тестирование случая 3. "Продажа компьютеров"
    /// </summary>
    [TestClass]
    public class ComputerSellingTest
    {
        [TestMethod]
        public void WhenBuyComputer_AndComputerCostsPrise_ThenPriceIsRemovingFromBuyer()
        {
            // Arrange.
            int buyerMoney = 50;
            int computerPrice = 10;
            IInventory buyer = new Inventory(money: buyerMoney);
            ISellable computer = new SellableComputer(price: computerPrice);
            IInventory shopInventory = new Inventory(
                goods: new List<ISellable>() { computer });
            IShop shop = new Shop(inventory: shopInventory);

            int expectedBuyerMoney = buyerMoney - computerPrice;

            // Act.
            shop.Buy(computer, buyer);

            // Assert.
            Assert.AreEqual(expectedBuyerMoney, buyer.Money);
        }

        [TestMethod]
        public void WhenBuyComputer_AndComputerCostsPrise_ThenPriceIsAddingToShop()
        {
            // Arrange.
            int buyerMoney = 50;
            int startShopMoney = 20;
            int computerPrice = 10;
            IInventory buyer = new Inventory(money: buyerMoney);
            ISellable computer = new SellableComputer(price: computerPrice);
            IInventory shopInventory = new Inventory(
                goods: new List<ISellable>() { computer }, 
                money: startShopMoney);
            IShop shop = new Shop(inventory: shopInventory);

            int expectedShopMoney = startShopMoney + computerPrice;

            // Act.
            shop.Buy(computer, buyer);

            // Assert.
            Assert.AreEqual(expectedShopMoney, shop.Money);
        }

        [TestMethod]
        public void WhenBuyComputer_AndComputerThereIsInShop_ThenComputerIsRemovingFromShop()
        {
            // Arrange.
            IInventory buyer = new Inventory();
            ISellable computer = new SellableComputer();
            IInventory shopInventory = new Inventory(
                goods: new List<ISellable>() { computer });
            IShop shop = new Shop(inventory: shopInventory);

            // Act.
            shop.Buy(computer, buyer);

            // Assert.
            Assert.IsFalse(shop.Goods.Contains(computer));
        }

        [TestMethod]
        public void WhenBuyComputer_AndComputerThereIsInShop_ThenComputerIsAppearingInBuyerInventory()
        {
            // Arrange.
            IInventory buyer = new Inventory();
            ISellable computer = new SellableComputer();
            IInventory shopInventory = new Inventory(
                goods: new List<ISellable>() { computer });
            IShop shop = new Shop(inventory: shopInventory);

            // Act.
            shop.Buy(computer, buyer);

            // Assert.
            Assert.IsTrue(buyer.Goods.Contains(computer));
        }

        [TestMethod]
        public void WhenBuyComputer_AndComputerThereIsNotInShop_ThenThrowingException()
        {
            // Arrange.
            IInventory buyer = new Inventory();
            ISellable computer = new SellableComputer();
            IInventory shopInventory = new Inventory();
            IShop shop = new Shop(inventory: shopInventory);

            // Act.
            
            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => shop.Buy(computer, buyer));
        }

        [TestMethod]
        public void WhenBuyComputer_AndComputerBuyerHasNotEnaugthMoney_ThenThrowingException()
        {
            // Arrange.
            int buyerMoney = 10;
            int computerPrice = 20;
            IInventory buyer = new Inventory(money: buyerMoney);
            ISellable computer = new SellableComputer(price: computerPrice);
            IInventory shopInventory = new Inventory(
                goods: new List<ISellable>() { computer });
            IShop shop = new Shop(inventory: shopInventory);

            // Act.

            // Assert.
            Assert.ThrowsException<InvalidOperationException>(() => shop.Buy(computer, buyer));
        }

        [TestMethod]
        public void WhenCreateInventory_AndMoneyIsLessZero_ThenThrowingException()
        {
            // Arrange.
            int money = -10;

            // Act.

            // Assert.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                IInventory buyer = new Inventory(money: money);
            });
        }
    }
}
