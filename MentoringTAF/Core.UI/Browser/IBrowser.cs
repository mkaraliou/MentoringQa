using OpenQA.Selenium;

namespace Core.UI.Browser
{
    public interface IBrowser
    {
        string Url { get; set; }

        string Title { get; }

        string PageSource { get; }

        string CurrentWindowHandle { get; }

        IReadOnlyCollection<string> WindowHandles { get; }

        void Close();

        void Quit();

        Screenshot GetScreenshot();

        IOptions Manage();

        INavigation Navigate();

        ITargetLocator SwitchTo();

        object ExecuteScript(string script);

        IWebElement FindElement(By locator);
    }
}
