using System;
using System.Collections.Generic;

namespace ComputersTask
{
    /// <summary>
    /// Основной класс компьютера. Специфика задания заставляет меня подозревать, что от меня хотят видеть сегрегацию интерфйсов.
    /// Так что тут много интерфейсов. Каждый отвечает за те возможности компьютера, которые интересны в определенной ситуации, абстрагируя от всего остального
    /// TODO: Сделать деталь "накопитель" и организовать установку приложений на него
    /// </summary>
    public class Computer : ISwitchable, IInstallingSuitable, IAssemblableComputer
    {
        private bool _isOn;
        private readonly List<IApplication> _applications;
        private readonly IAssemblableComputer _details;

        public event Action SwitchedOff;

        public bool IsOn => _isOn;

        public IReadOnlyList<IComputerDetail> Details => _details.Details;

        public Computer(bool isOn = false, bool hasToCreateDetails = true)
        {
            _applications = new List<IApplication>();
            _details = new AssemblableComputer(master: this, hasToCreateDetails: hasToCreateDetails);
            if (IsAssembled() == false && isOn)
                throw new ArgumentException(nameof(isOn));

            _isOn = isOn;
        }

        public Computer(HashSet<IComputerDetail> details, bool isOn = false)
        {
            _applications = new List<IApplication>();
            _details = new AssemblableComputer(master: this, details: details);
            if (IsAssembled() == false && isOn)
                throw new ArgumentException(nameof(isOn));

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

            if (_details.IsAssembled() == false)
                throw new InvalidOperationException();

            _isOn = true;
        }

        public void Reboot()
        {
            SwitchOff();
            SwitchOn();
        }

        public bool HasApplication(IApplication application)
        {
            return _applications.Contains(application);
        }

        public void Install(IApplication application)
        {
            if (HasApplication(application))
                throw new InvalidOperationException();

            if (_isOn == false)
                throw new InvalidOperationException();

            _applications.Add(application);
        }

        public void AddDetail(IComputerDetail detail)
        {
            _details.AddDetail(detail);
        }

        public void RemoveDetail(IComputerDetail detail)
        {
            if (_isOn)
                SwitchOff();

            _details.RemoveDetail(detail);
        }

        public bool IsAssembled()
        {
            return _details.IsAssembled();
        }
    }
}
