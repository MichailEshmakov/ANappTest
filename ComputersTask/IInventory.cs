using System.Collections.Generic;

namespace ComputersTask
{
    /// <summary>
    /// Интерфейс инвентаря. Обязывает иметь вещи и деньги и обеспечить возможность изменять их количество.
    /// </summary>
    public interface IInventory
    {
        int Money { get; }
        IReadOnlyList<ISellable> Goods { get; }

        void RemoveMoney(int value);
        void AddMoney(int value);
        void AddItem(ISellable good);
        void RemoveItem(ISellable good);
    }
}