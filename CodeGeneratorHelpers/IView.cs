namespace CodeGeneratorHelpers
{
    public interface IView
    {
        string viewContent { get;}
        string viewExtension { get; }
        string createFromT4Template();
    }
}