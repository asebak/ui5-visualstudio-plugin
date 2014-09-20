using System;

namespace CodeGeneratorHelpers
{
    public sealed class JavascriptView: View, IView
    {
        
        public JavascriptView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.JS";
        }
        public string viewExtension { get { return "js"; } }
        public string createFromT4Template(SapUI5ProjectType type)
        {
            throw new NotImplementedException();
        }
    }
}
