namespace Core.UI.Elements.Interfaces
{
    public interface IFieldInput : IBaseElement
    {
        string Text { get; }

        void EnterText(string text, bool isClearNeeded = true);
    }
}
