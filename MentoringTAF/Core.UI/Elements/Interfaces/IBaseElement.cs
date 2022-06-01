using OpenQA.Selenium;

namespace Core.UI.Elements.Interfaces
{
    public interface IBaseElement
    {
        IWebElement WebElement { get; }
        void ManualClearField();
        bool Enabled();
    }
}
