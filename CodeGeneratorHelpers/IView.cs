namespace CodeGeneratorHelpers
{
    public interface IView
    {
        string viewContent { get; set; }
        void createFromT4Template();
    }
}