using System;

namespace ComputersTask
{
    /// <summary>
    /// Деталь компьютера. При установки ставит себе в качестве компьютера тот, в который устанавливается.
    /// Может плавиться, если не в компьютере и уже не плавилась.
    /// </summary>
    public class ComputerDetail : IComputerDetail, IMeltable
    {
        private readonly ComputerDetailType _detailType;
        private IAssemblableComputer _computer;
        private bool _isMelted = false;
        private readonly int _metal;

        public IAssemblableComputer Computer => _computer;
        public ComputerDetailType DetailType => _detailType;
        public bool IsMelted => _isMelted;

        public ComputerDetail(ComputerDetailType detailType, IAssemblableComputer computer = null, int metal = 0)
        {
            _detailType = detailType;

            if (metal < 0)
                throw new ArgumentOutOfRangeException(nameof(metal));

            if (computer != null)
                SetInComputer(computer);

            _metal = metal;
        }

        public void SetInComputer(IAssemblableComputer computer)
        {
            if (computer == null)
                throw new ArgumentNullException(nameof(computer));

            if (_computer != null)
                throw new InvalidOperationException();

            if (_isMelted)
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

        public int Melt()
        {
            if (_computer != null)
                throw new InvalidOperationException();

            if (_isMelted)
                throw new InvalidOperationException();

            _isMelted = true;
            return _metal;
        }
    }
}
