using Core.UI.Elements.Interfaces;

namespace PageObjects.Interfaces
{
    public interface ILoginPage
    {
        public IFieldInput Login { get; }
        public IFieldInput Password { get; }
        public IButton LoginButton { get; }
        public ITextField TextError { get; }
    }
}
