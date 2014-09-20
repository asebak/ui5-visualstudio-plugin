using System;

namespace CodeGeneratorHelpers
{
    public sealed class JSONView: View, IView
    {
        public JSONView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.JSON";
        }
        public string createFromT4Template(SapUI5ProjectType type)
        {
            throw new NotImplementedException();
        }

        public string viewExtension { get { return "json"; } }

    }
}
