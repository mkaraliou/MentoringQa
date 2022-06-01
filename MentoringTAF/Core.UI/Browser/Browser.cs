using OpenQA.Selenium;
using Serilog;

namespace Core.UI.Browser
{
    public class Browser : IBrowser
    {
        private readonly IWebDriver webDriver;

        public Browser(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string Url
        {
            get => webDriver.Url;

            set
            {
                Log.Logger.Information($"Go to {value}");
                webDriver.Url = value;
            }
        }

        public string Title => webDriver.Title;

        public string PageSource => webDriver.PageSource;

        public string CurrentWindowHandle => webDriver.CurrentWindowHandle;

        public IReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;

        public void Close() => webDriver.Close();

        public void Dispose() => webDriver.Dispose();

        public void Quit() => webDriver.Quit();

        public Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)webDriver).GetScreenshot();
        }

        public IOptions Manage() => webDriver.Manage();

        public INavigation Navigate() => webDriver.Navigate();

        public ITargetLocator SwitchTo() => webDriver.SwitchTo();

        public object ExecuteScript(string script) => ((IJavaScriptExecutor)webDriver).ExecuteScript(script);

        public IWebElement FindElement(By locator)
        {
            return webDriver.FindElement(locator);
        }
    }
}
