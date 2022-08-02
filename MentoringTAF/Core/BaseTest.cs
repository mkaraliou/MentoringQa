using Core.Configuration;
using Core.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;
using System.Reflection;
using Xunit;

namespace Core
{
    [TestFixture]
    public class BaseTest //: IClassFixture<BaseTest>
    {
        public BaseTest()
        {
            BaseTestInitialize();
            Log.Logger.Information("BaseTest initialize.");

        }

        public TestCore TestCore { get; set; }

        public IConfiguration Configuration { get; set; }

        public ITimeoutWaiter Waiter { get; set; }

        public static TestSettings TestConfiguration => ConfigurationHelper.GetApplicationConfiguration<TestSettings>();

        [OneTimeSetUp]
        public void BaseTestInitialize()
        {
            Configuration = ConfigurationHelper.GetConfigurationRoot();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("C:\\Users\\Mikalai_Karaliou\\Work\\MentoringQa\\MentoringTAF\\logs\\log.txt")
               //.ReadFrom.Configuration(Configuration.GetSection("Serilog"))
               .CreateLogger();

            TestCore = new TestCore();
            TestCore.Container.RegisterTypes(Assembly.GetExecutingAssembly());

            Waiter = TestCore.Container.GetInstance<ITimeoutWaiter>();

            //Log.Logger.Information("OneTimeSetUp BaseTest initialize.");
        }
    }
}
