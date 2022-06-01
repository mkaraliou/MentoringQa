using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;

namespace Core.UI.Elements
{
    public class Button : BaseElement, IButton
    {
        public Button(IWebElement webElement)
            : base(webElement)
        {
        }

        public Button(By locator)
            : base(locator)
        {
        }

        public override void Click()
        {
            base.Click();
        }
    }
}
