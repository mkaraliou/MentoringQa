using Core.UI.Elements;
using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;
using PageObjects.Interfaces;

namespace PageObjects
{
    public class GoogleMain : IGoogleMain
    {
        public ITextField GoogleImage => new TextField(By.XPath("//img[@class='lnXdpd']"));

        public IFieldInput GoogleFind => new FieldInput(By.XPath("//input[@class='gLFyf gsfi']"));

        public IButton FirstLink => new Button(By.XPath("(//h3[@class='LC20lb MBeuO DKV0Md'])[1]"));
    }
}
