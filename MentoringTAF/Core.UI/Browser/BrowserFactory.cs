using Core.Configuration;
using Core.UI.Enums;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Serilog;
using System.Reflection;

namespace Core.UI.Browser
{
    public class BrowserFactory
    {
        private static readonly Lazy<BrowserFactory> _lazy = new Lazy<BrowserFactory>(() => new BrowserFactory());

        private static string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static TestSettings TestConfiguration => ConfigurationHelper.GetApplicationConfiguration<TestSettings>();

        public static BrowserFactory Instance => _lazy.Value;

        private BrowserFactory()
        {

        }

        public IBrowser GetDriver()
        {
            Enum.TryParse(TestConfiguration.BrowserType, out BrowserType browserType);
            return GetDriver(browserType);
        }

        public IBrowser GetHeadlessBrowser()
        {
            return InitialzeHeadlessDriver();
        }

        private IBrowser InitialzeHeadlessDriver()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments(
                    "headless",
                    "allow-running-insecure-content",
                    "disable-gpu",
                    "disable-extensions",
                    "ignore-certificate-errors");

                var driver = new ChromeDriver(AssemblyLocation, options);

                return new Browser(driver);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw;
            }
        }

        private IBrowser GetDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.RemoteChrome:
                    return InitializeRemoteChromeDriver();
                case BrowserType.Chrome:
                    return InitializeChromeDriver();
                case BrowserType.SauseLabs_Firefox:
                    return InitializeSauceLabsFirefox();
                default:
                    throw new Exception($"Unknown browser: {browser}");
            }
        }

        private IBrowser InitializeRemoteChromeDriver()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments(
                    "start-maximized",
                    "allow-running-insecure-content",
                    "test-type",
                    "disable-gpu",
                    "disable-extensions");

                var driver = new RemoteWebDriver(new Uri(TestConfiguration.GridUrl), options);

                return new Browser(driver);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw;
            }
        }

        private IBrowser InitializeChromeDriver()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments(
                    "start-maximized",
                    "allow-running-insecure-content",
                    "test-type",
                    "disable-gpu",
                    "disable-extensions",
                    "ignore-certificate-errors");
                options.AddArgument("no-sandbox");

                var driver = new ChromeDriver(AssemblyLocation, options);

                return new Browser(driver);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw;
            }
        }

        private IBrowser InitializeSauceLabsFirefox()
        {
            var browserOptions = new FirefoxOptions();
            browserOptions.PlatformName = "Windows 10";
            browserOptions.BrowserVersion = "latest";
            browserOptions.AddAdditionalOption("username", "MKaraliou");
            browserOptions.AddAdditionalOption("accessKey", "df310b2a-bda9-446f-b5a0-2a42289e7d61");
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("name", TestContext.CurrentContext.Test.MethodName);
            sauceOptions.Add("screenResolution", "1024x768");
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://MKaraliou:df310b2a-bda9-446f-b5a0-2a42289e7d61@ondemand.us-west-1.saucelabs.com:443/wd/hub");
            var driver = new RemoteWebDriver(uri, browserOptions);
            return new Browser(driver);
        }
    }
}
