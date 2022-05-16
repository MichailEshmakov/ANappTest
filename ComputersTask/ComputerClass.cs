using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputersTask
{
    /// <summary>
    /// Компьютерный класс
    /// </summary>
    public class ComputerClass : IComputerClass
    {
        private readonly List<IInstallingSuitable> _computers;

        public IReadOnlyList<IInstallingSuitable> Computers => _computers;

        public ComputerClass(List<IInstallingSuitable> computers)
        {
            if (computers.Count != computers.Distinct().Count())
                throw new ArgumentException(nameof(computers));

            _computers = computers;
        }

        public void Install(int computerIndex, IApplication application)
        {
            _computers[computerIndex].Install(application);
        }
    }
}
