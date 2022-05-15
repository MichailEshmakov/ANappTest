using System.Collections.Generic;

namespace ComputersTask
{
    /// <summary>
    /// Интерфес магазина. Обязывает иметь вещи и деньги и иметь возможность покупать вещи.
    /// </summary>
    public interface IShop
    {
        IReadOnlyList<ISellable> Goods { get; }
        int Money { get; }

        void Buy(ISellable computer, IInventory buyer);

    }
}