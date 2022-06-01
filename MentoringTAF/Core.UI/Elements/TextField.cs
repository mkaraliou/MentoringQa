using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;

namespace Core.UI.Elements
{
    public class TextField : BaseElement, ITextField
    {
        public TextField(By locator)
            : base(locator)
        {
        }
    }
}
