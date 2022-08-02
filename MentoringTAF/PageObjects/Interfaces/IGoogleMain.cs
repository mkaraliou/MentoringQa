using Core.UI.Elements;
using Core.UI.Elements.Interfaces;
using OpenQA.Selenium;

namespace PageObjects.Interfaces
{
    public interface IGoogleMain
    {
        ITextField GoogleImage { get; }

        IFieldInput GoogleFind { get; }

        IButton FirstLink { get; }
    }
}
