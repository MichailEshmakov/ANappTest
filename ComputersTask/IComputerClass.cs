using System.Collections.Generic;

namespace ComputersTask
{
    /// <summary>
    /// Интерфейс компьютерного класса.
    /// В компьютерном классе должны быть компьютеры, на которые можно устанавливать приложения
    /// </summary>
    public interface IComputerClass
    {
        IReadOnlyList<IInstallingSuitable> Computers { get; }

        void Install(int computerIndex, IApplication application);
    }
}