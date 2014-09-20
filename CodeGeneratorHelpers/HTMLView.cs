using System;

namespace CodeGeneratorHelpers
{
    public sealed class HTMLView: View, IView
    {
        public HTMLView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.HTML";
        }

        public string viewContent { get; set; }
        public void createFromT4Template()
        {
            throw new NotImplementedException();
        }
    }
}
