using System;

namespace ComputersTask
{
    /// <summary>
    /// Интерфейс, обязывающий включение/выключение
    /// </summary>
    public interface ISwitchable
    {
        bool IsOn { get; }
        event Action SwitchedOff;

        void SwitchOff();
        void SwitchOn();
        void Reboot();
    }
}