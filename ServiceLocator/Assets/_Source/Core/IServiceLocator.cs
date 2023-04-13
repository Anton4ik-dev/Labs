namespace Core
{
    public interface IServiceLocator
    {
        bool GetService<T>(out T service);
        void RegisterService<T>(IGameService service);
        void DeleteService<T>();
    }
}