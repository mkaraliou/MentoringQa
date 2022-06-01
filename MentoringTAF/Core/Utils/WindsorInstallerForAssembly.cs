using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Core.Utils
{
    public class WindsorInstallerForAssembly : IWindsorInstaller
    {
        public Assembly Assembly { get; set; }

        /// <inheritdoc/>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(Assembly).Pick()
                .WithService.DefaultInterfaces().LifestyleTransient());
        }
    }
}
