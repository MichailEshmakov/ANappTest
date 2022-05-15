namespace ComputersTask
{
    /// <summary>
    /// Интерфейс, обязывающий иметь возможность установки приложений
    /// </summary>
    public interface IInstallingSuitable : ISwitchable
    {
        bool HasApplication(IApplication application);
        void Install(IApplication application);
    }
}