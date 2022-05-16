using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersTask
{
    /// <summary>
    /// Продваемый компьютер. Надстройка над компьютером, позволяющая его продавать.
    /// </summary>
    public class SellableComputer : ISellable
    {
        private int _price;
        private IInstallingSuitable _computer;

        public int Price => _price;

        public SellableComputer(int price = 0, IInstallingSuitable computer = null)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));

            if (computer == null)
                computer = new Computer();

            _price = price;
            _computer = computer;
        }
    }
}
