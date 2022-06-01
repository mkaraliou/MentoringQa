using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;

namespace Core.UI.Elements
{
    public class FieldInput : BaseElement, IFieldInput
    {
        public FieldInput(IWebElement webElement)
            : base(webElement)
        {
        }

        public FieldInput(By locator)
            : base(locator)
        {
        }

        public string Text
        {
            get
            {
                try
                {
                    return WebElement.GetAttribute("value");
                }
                catch
                {
                    return null;
                }
            }
        }

        public override void EnterText(string text, bool isClearNeeded = true)
        {
            base.EnterText(text, isClearNeeded);
        }
    }
}
