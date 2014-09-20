using System;

namespace CodeGeneratorHelpers
{
    public sealed class HTMLView: View, IView
    {
        public HTMLView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.HTML";
        }
        public string viewExtension { get { return "html"; } }
        public string createFromT4Template()
        {
            throw new NotImplementedException();
        }
    }
}
