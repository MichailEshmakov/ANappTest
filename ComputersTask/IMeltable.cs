namespace ComputersTask
{
    /// <summary>
    /// Интерфейс плавящейся вещи. Обязывает плавиться, отдавая значение, и обозначать статус плавленности.
    /// </summary>
    public interface IMeltable
    {
        bool IsMelted { get; }

        int Melt();
    }
}