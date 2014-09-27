using System;
using System.Collections.Generic;

namespace CodeGeneratorHelpers
{
    public sealed class JavascriptView: View, IView
    {
        
        public JavascriptView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.JS";
        }
        public string viewExtension { get { return "js"; } }
        public string createFromT4Template(UI5ProjectType type)
        {
            var jsTemplate = new T4.JSView
            {
                Session =
                    new Dictionary<string, object>
                    {
                        {"ControllerName", this.ControllerName},
                        {"IsMobile", type == UI5ProjectType.Mobile}
                    }
            };
            jsTemplate.Initialize();
            return jsTemplate.TransformText();
        }
    }
}
