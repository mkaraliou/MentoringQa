using Core.UI.Elements;
using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;
using PageObjects.Interfaces;

namespace PageObjects
{
    public class LoginPage : ILoginPage
    {
        public IFieldInput Login => new FieldInput(By.XPath("(.//input)[1]"));
        public IFieldInput Password => new FieldInput(By.XPath("(.//input)[2]"));
        public IButton LoginButton => new Button(By.XPath("(.//button)[2]"));
        public ITextField TextError => new TextField(By.XPath("(.//p)[1]"));
    }
}
