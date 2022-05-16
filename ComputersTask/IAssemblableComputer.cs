using System;
using System.Collections.Generic;

namespace ComputersTask
{
    /// <summary>
    /// Интерфейс собираемого компьютера. Обязывает иметь детали, а также их добавлять, удалять и проверять себя на собранность.
    /// </summary>
    public interface IAssemblableComputer
    {
        IReadOnlyList<IComputerDetail> Details { get; }

        void AddDetail(IComputerDetail detail);
        void RemoveDetail(IComputerDetail detail);
        bool IsAssembled();
    }
}