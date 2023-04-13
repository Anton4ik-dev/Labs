namespace Core
{
    public interface IServiceLocator
    {
        bool GetService<T>(out T service);
    }
}