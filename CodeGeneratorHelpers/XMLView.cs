using System;

namespace CodeGeneratorHelpers
{
    public sealed class XMLView : View, IView
    {
        public XMLView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.XML";
        }

        public string viewContent { get; set; }
        public void createFromT4Template()
        {
            throw new NotImplementedException();
        }
    }
}
