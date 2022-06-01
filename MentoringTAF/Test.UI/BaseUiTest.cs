using Core;
using Core.UI.Browser;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;
using System.Reflection;

namespace Test.UI
{
    [TestFixture]
    public class BaseUiTest : BaseTest
    {
        public IBrowser Driver;

        [OneTimeSetUp]
        public void BaseUiInitialize()
        {
            //Assembly loginPageAssembly = typeof(LoginPage).Assembly;
            //TestCore.Container.RegisterTypes(loginPageAssembly);
            Log.Logger.Information("Base UI initialize.");
            Driver = BrowserFactory.Instance.GetDriver();
            Driver.Navigate().GoToUrl(Configuration.GetValue<string>("TestSettings:BaseUrl"));
        }

        [OneTimeTearDown]
        public void BaseUiCleanup()
        {
            Driver.Quit();
            Log.Logger.Information("Browser is quited.");
        }
    }
}
