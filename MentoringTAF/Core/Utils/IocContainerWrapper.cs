using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Core.Utils
{
    public class IocContainerWrapper
    {
        private IWindsorContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="IocContainerWrapper"/> class.
        /// </summary>
        internal IocContainerWrapper()
        {
            _container = new WindsorContainer();
            RegisterTypes();
        }

        /// <summary>
        /// Register types of wrapper.
        /// </summary>
        public void RegisterTypes()
        {
            _container.Install(new RepositoriesInstaller());
        }

        /// <summary>
        /// Register types of wrapper.
        /// </summary>
        public void RegisterTypes(Assembly assembly)
        {
            var installer = new WindsorInstallerForAssembly();
            installer.Assembly = assembly;
            _container.Install(installer);
        }

        /// <summary>
        /// Register instance of wrapper.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="obj">Type to register.</param>
        public void RegisterInstance<T>(T obj)
            where T : class
        {
            _container.Register(Component.For<T>().Instance(obj).IsDefault().Named("Overridden" + Guid.NewGuid().ToString()));
        }

        /// <summary>
        /// Gets instance of wrapper.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
