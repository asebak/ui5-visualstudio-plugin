namespace CodeGeneratorHelpers
{
    public interface IView
    {
        string viewExtension { get; }
        string createFromT4Template(UI5ProjectType type);
    }
}