using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGeneratorHelpers;

namespace T4
{
    public sealed class JSONView: View, IView
    {
        public JSONView(string controllerName) : base(controllerName)
        {
            this.MVCViewType = "sap.ui.core.mvc.ViewType.JSON";
        }

        public string viewContent { get; set; }
        public void createFromT4Template()
        {
            throw new NotImplementedException();
        }
    }
}
