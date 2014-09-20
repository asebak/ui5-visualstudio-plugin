using System;
using System.Collections.Generic;

namespace CodeGeneratorHelpers
{
    public sealed class XMLView : View, IView
    {
        public XMLView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.XML";
        }
        public string viewExtension { get { return "xml"; }}
        public string createFromT4Template(SapUI5ProjectType type)
        {
            var xmlTemplate = new T4.XMLView
            {
                Session =
                    new Dictionary<string, object>
                    {
                        {"ControllerName", this.ControllerName},
                        {"IsMobile", type == SapUI5ProjectType.Mobile}
                    }
            };
            xmlTemplate.Initialize();
            return xmlTemplate.TransformText();
        }
    }
}
