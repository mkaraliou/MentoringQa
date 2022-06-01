using Core.Utils;

namespace Core
{
    public class TestCore
    {
        public TestCore()
        {
            Container = new IocContainerWrapper();
            Container.RegisterInstance(this);
        }

        public IocContainerWrapper Container { get; private set; }
    }
}
