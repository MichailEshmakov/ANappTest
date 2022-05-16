using System;
using System.Collections.Generic;

namespace ComputersTask
{
    /// <summary>
    /// Инвентарь. Хранит вещи и деньги
    /// </summary>
    public class Inventory : IInventory
    {
        private int _money;
        private readonly List<ISellable> _goods;

        public int Money => _money;
        public IReadOnlyList<ISellable> Goods => _goods;

        public Inventory(int money = 0, List<ISellable> goods = null)
        {
            if (money < 0)
                throw new ArgumentOutOfRangeException(nameof(money));

            if (goods == null)
                goods = new List<ISellable>();

            _money = money;
            _goods = goods;
        }

        public void AddItem(ISellable good)
        {
            if (_goods.Contains(good))
                throw new InvalidOperationException();

            _goods.Add(good);
        }

        public void AddMoney(int value)
        {
            _money += value;
        }

        public void RemoveItem(ISellable good)
        {
            if (_goods.Contains(good) == false)
                throw new InvalidOperationException();

            _goods.Remove(good);
        }

        public void RemoveMoney(int value)
        {
            if (_money < value)
                throw new InvalidOperationException();

            _money -= value;
        }
    }
}
