using System;
using System.Collections.Generic;

namespace CodeGeneratorHelpers
{
    public sealed class HTMLView: View, IView
    {
        public HTMLView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.HTML";
        }
        public string viewExtension { get { return "html"; } }
        public string createFromT4Template(UI5ProjectType type)
        {
            var htmlTemplate = new T4.HTMLView
            {
                Session =
                    new Dictionary<string, object>
                    {
                        {"ControllerName", this.ControllerName},
                        {"IsMobile", type == UI5ProjectType.Mobile}
                    }
            };
            htmlTemplate.Initialize();
            return htmlTemplate.TransformText();
        }
    }
}
