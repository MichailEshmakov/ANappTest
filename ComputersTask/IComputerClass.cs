using System.Collections.Generic;

namespace ComputersTask
{
    public interface IComputerClass
    {
        IReadOnlyList<IInstallingSuitable> Computers { get; }

        void Install(int computerIndex, IApplication application);
    }
}