namespace Core.Utils
{
    public interface ITimeoutWaiter
    {
        T WaitUntil<T>(Func<T> action, Func<T, bool> condition, int? timeout = null);
    }
}
