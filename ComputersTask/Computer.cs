using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersTask
{
    /// <summary>
    /// Основной класс компьютера. Специфика задания заставляет меня подозревать, что от меня хотят видеть сегрегацию интерфйсов.
    /// Так что тут много интерфейсов. Каждый отвечает за те возможности компьютера, которые интересны в определенной ситуации, абстрагируя от всего остального
    /// </summary>
    public class Computer : ISwitchable
    {
        private bool _isOn;

        public event Action SwitchedOff;

        public bool IsOn => _isOn;

        public Computer(bool isOn = false)
        {
            _isOn = isOn;
        }

        public void SwitchOff()
        {
            if (_isOn == false)
                throw new InvalidOperationException();

            _isOn = false;
            SwitchedOff?.Invoke();
        }

        public void SwitchOn()
        {
            if (_isOn)
                throw new InvalidOperationException();

            _isOn = true;
        }

        public void Reboot()
        {
            SwitchOff();
            SwitchOn();
        }
    }
}
