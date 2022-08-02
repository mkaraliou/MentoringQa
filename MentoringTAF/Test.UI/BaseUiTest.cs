using Core;
using Core.UI.Browser;
using Microsoft.Extensions.Configuration;
using PageObjects;
using Serilog;
using System.Reflection;

namespace Test.UI
{
    [TestFixture]
    public abstract class BaseUiTest : BaseTest
    {
        public IBrowser Driver => BrowserPool.CurrentBrowser;

        [SetUp]
        public void BaseUiInitialize()
        {
            Assembly loginPageAssembly = typeof(LoginPage).Assembly;
            TestCore.Container.RegisterTypes(loginPageAssembly);
            Log.Logger.Information("Base UI initialize.");

            var driver = BrowserFactory.Instance.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            BrowserPool.RegisterAndMakeCurrentBrowser(TestContext.CurrentContext.Test.Name, driver);

            Driver.Navigate().GoToUrl(TestConfiguration.BaseUrl);
        }

        [TearDown]
        public void BaseUiCleanup()
        {
            BrowserPool.CloseBrowser(TestContext.CurrentContext.Test.Name);
            Log.Logger.Information("Browser is quited.");
        }
    }
}
