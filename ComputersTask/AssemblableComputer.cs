using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputersTask
{
    /// <summary>
    /// Класс, ответсвенный за сборку компьютера из деталей.
    /// При установке детали проверяет, установился ли в качестве компьютера детали.
    /// </summary>
    public class AssemblableComputer : IAssemblableComputer
    {
        private readonly HashSet<IComputerDetail> _details = new HashSet<IComputerDetail>();
        private readonly IAssemblableComputer _master;

        public IReadOnlyList<IComputerDetail> Details => _details.ToList();

        public AssemblableComputer(bool hasToCreateDetails = true, IAssemblableComputer master = null)
        {
            if (hasToCreateDetails)
            {
                foreach (ComputerDetailType detailType in Enum.GetValues(typeof(ComputerDetailType)))
                {
                    IComputerDetail newDetail = new ComputerDetail(detailType, this);
                    if (_details.Contains(newDetail) == false)
                        throw new InvalidOperationException();
                }
            }

            _master = master;
        }

        public AssemblableComputer(HashSet<IComputerDetail> details, IAssemblableComputer master = null)
        {
            if (details == null)
                throw new ArgumentNullException(nameof(details));

            foreach (IComputerDetail detail in details)
            {
                detail.SetInComputer(this);
                if (_details.Contains(detail) == false)
                    throw new InvalidOperationException();
            }

            _master = master;
        }

        public void AddDetail(IComputerDetail detail)
        {
            if (detail == null)
                throw new ArgumentNullException(nameof(detail));

            if (detail.Computer != this && detail.Computer != _master)
                throw new ArgumentException(nameof(detail));

            if (_details.Any(existingDetail => existingDetail.DetailType == detail.DetailType))
                throw new ArgumentException(nameof(detail));

            _details.Add(detail);
        }

        public void RemoveDetail(IComputerDetail detail)
        {
            if (_details.Contains(detail) == false)
                throw new ArgumentException(nameof(detail));

            if (detail.Computer != null)
                throw new InvalidOperationException();

            _details.Remove(detail);
        }

        public bool IsAssembled()
        {
            return _details.Count == Enum.GetValues(typeof(ComputerDetailType)).Length;
        }
    }
}
