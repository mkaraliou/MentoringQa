using Core.Configuration;
using Core.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;
using System.Reflection;

namespace Core
{
    [TestFixture]
    public abstract class BaseTest
    {
        public TestCore TestCore { get; set; }

        public IConfiguration Configuration { get; set; }

        public ITimeoutWaiter Waiter { get; set; }

        public static TestSettings TestConfiguration => ConfigurationHelper.GetApplicationConfiguration<TestSettings>();

        [OneTimeSetUp]
        public void BaseTestInitialize()
        {
            Configuration = ConfigurationHelper.GetConfigurationRoot();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(Configuration.GetSection("Serilog"))
               .CreateLogger();

            TestCore = new TestCore();
            TestCore.Container.RegisterTypes(Assembly.GetExecutingAssembly());

            Waiter = TestCore.Container.GetInstance<ITimeoutWaiter>();

            Log.Logger.Information("Base initialize.");
        }
    }
}
