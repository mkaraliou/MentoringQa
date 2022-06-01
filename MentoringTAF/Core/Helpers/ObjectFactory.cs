using System;

namespace Core.Helpers
{
    public static class ObjectFactory
    {
        public static T Get<T>(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        public static T Get<T>(Type type, params object[] args)
        {
            return (T)Activator.CreateInstance(type, args);
        }
    }
}
