using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputersTask
{
    /// <summary>
    /// Магазин. Может продвать компьютеры
    /// </summary>
    public class Shop : IShop
    {
        private readonly IInventory _inventory;

        public IReadOnlyList<ISellable> Goods => _inventory.Goods;
        public int Money => _inventory.Money;

        public Shop(IInventory inventory)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            _inventory = inventory;
        }

        public void Buy(ISellable good, IInventory buyer)
        {
            if (buyer == null)
                throw new ArgumentNullException(nameof(buyer));

            if (Goods.Contains(good) == false)
                throw new InvalidOperationException();

            buyer.RemoveMoney(good.Price);
            _inventory.AddMoney(good.Price);
            _inventory.RemoveItem(good);
            buyer.AddItem(good);
        }
    }
}
