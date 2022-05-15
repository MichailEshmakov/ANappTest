namespace ComputersTask
{
    /// <summary>
    /// Интерфейс продаваемой вещи. Обязывает иметь цену
    /// </summary>
    public interface ISellable
    {
        int Price { get; }
    }
}