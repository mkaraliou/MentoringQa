using Core.UI.Browser;
using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;
using Serilog;

namespace Core.UI.Elements
{
    public abstract class BaseElement : IBaseElement
    {
        private readonly By _elementLocator;
        private IWebElement _webElement;
        private int _counterForStaleException;

        public IBrowser Driver => BrowserFactory.Instance.GetDriver();

        public BaseElement(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public BaseElement(By locator)
        {
            _elementLocator = locator;
        }

        public IWebElement WebElement => GetElementAndVerifyNotStale();

        public virtual void Click()
        {
            try
            {
                if (WebElement.Displayed)
                {
                    WebElement.Click();
                }
                else
                {
                    Log.Logger.Warning($"Element {WebElement} is not displayed");
                }
            }
            catch (WebDriverException exception)
            {
                Log.Logger.Warning($"WebDriverException: {exception.StackTrace}");
            }
        }

        public virtual void EnterText(string text, bool isClearNeeded = true)
        {
            if (isClearNeeded)
            {
                try
                {
                    WebElement.Clear();

                    if (!WebElement.GetAttribute("value").Equals(string.Empty))
                    {
                        ManualClearField();
                    }
                }
                catch (StaleElementReferenceException)
                {
                    ReInitializeAfterStaleException();
                }
            }

            WebElement.SendKeys(text);
        }

        public void ManualClearField()
        {
            while (!WebElement.GetAttribute("value").Equals(string.Empty))
            {
                WebElement.SendKeys(Keys.Backspace);
            }
        }

        public bool Enabled()
        {
            return WebElement.Enabled;
        }

        private IWebElement GetElementAndVerifyNotStale()
        {
            var element = _webElement ?? Driver.FindElement(_elementLocator);

            try
            {
                var isEnabled = element.Enabled;
            }
            catch (StaleElementReferenceException)
            {
                ReInitializeAfterStaleException();
                return _webElement;
            }

            return element;
        }

        private void ReInitializeAfterStaleException()
        {
            // Limit of attempts if reinitialize method is looped (in case of recursion)
            if (_counterForStaleException > 5)
            {
                throw new Exception("Limit for StaleElementReferenceException exceeded.");
            }

            try
            {
                _webElement = Driver.FindElement(_elementLocator);
            }
            catch (NullReferenceException exception)
            {
                Log.Logger.Warning($"NullReferenceException: {exception.StackTrace}.");
            }
            catch (WebDriverException exception)
            {
                Log.Logger.Warning($"WebDriverException: {exception.StackTrace}.");
            }

            _counterForStaleException++;
        }
    }
}
