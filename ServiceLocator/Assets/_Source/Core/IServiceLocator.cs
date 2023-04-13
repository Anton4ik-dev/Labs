namespace Core
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}