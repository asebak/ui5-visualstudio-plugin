using System;
using System.Collections.Generic;

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
            var jsonTemplate = new T4.JSONView
            {
                Session =
                    new Dictionary<string, object>
                    {
                        {"ControllerName", this.ControllerName},
                        {"IsMobile", type == SapUI5ProjectType.Mobile}
                    }
            };
            jsonTemplate.Initialize();
            return jsonTemplate.TransformText();
        }

        public string viewExtension { get { return "json"; } }

    }
}
