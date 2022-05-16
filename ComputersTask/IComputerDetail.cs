namespace ComputersTask
{
    /// <summary>
    /// Интерфейс детали компьютера. Обязывает иметь тип и компьютер, а также устанавливаться и удаляться.
    /// </summary>
    public interface IComputerDetail
    {
        IAssemblableComputer Computer { get; }
        ComputerDetailType DetailType { get; }

        void SetInComputer(IAssemblableComputer computer);
        void RemoveFromComputer();
    }
}