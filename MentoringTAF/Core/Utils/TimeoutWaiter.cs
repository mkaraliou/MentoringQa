namespace Core.Utils
{
    public class TimeoutWaiter : ITimeoutWaiter
    {
        public TimeoutWaiter()
        {
            IterationDelay = TimeSpan.FromMilliseconds(100);
            MaximumDuration = TimeSpan.FromSeconds(60);
        }

        public TimeSpan IterationDelay { get; set; }

        public TimeSpan MaximumDuration { get; set; }

        public T WaitUntil<T>(Func<T> action, Func<T, bool> condition, int? timeout = null)
        {
            var endTime = DateTime.UtcNow.Add(timeout == null ? MaximumDuration : TimeSpan.FromSeconds((double)timeout));
            T result;
            do
            {
                result = action();
                if (!condition(result))
                {
                    Thread.Sleep(IterationDelay);
                }
            }
            while (!condition(result) && DateTime.UtcNow <= endTime);

            return result;
        }
    }
}
