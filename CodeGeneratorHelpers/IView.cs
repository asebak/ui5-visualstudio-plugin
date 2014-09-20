namespace CodeGeneratorHelpers
{
    public interface IView
    {
        string viewExtension { get; }
        string createFromT4Template(SapUI5ProjectType type);
    }
}