using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersTask
{
    /// <summary>
    /// Деталь компьютера. При установки ставит себе в качестве компьютера тот, в который устанавливается.
    /// </summary>
    public class ComputerDetail : IComputerDetail
    {
        private readonly ComputerDetailType _detailType;
        private IAssemblableComputer _computer;

        public IAssemblableComputer Computer => _computer;
        public ComputerDetailType DetailType => _detailType;

        public ComputerDetail(ComputerDetailType detailType, IAssemblableComputer computer = null)
        {
            _detailType = detailType;

            if (computer != null)
                SetInComputer(computer);
        }

        public void SetInComputer(IAssemblableComputer computer)
        {
            if (computer == null)
                throw new ArgumentNullException(nameof(computer));

            if (_computer != null)
                throw new InvalidOperationException();

            _computer = computer;
            _computer.AddDetail(this);
        }

        public void RemoveFromComputer()
        {
            if (_computer == null)
                throw new InvalidOperationException();

            IAssemblableComputer computer = _computer;
            _computer = null;
            computer.RemoveDetail(this);
        }
    }
}
