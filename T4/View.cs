using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4
{
    public class View
    {
        protected string ControllerName { get; private set; }
        protected virtual string MVCViewType { get; set; }
        public View(string controllerName)
        {
            this.ControllerName = controllerName;
        }
    }
}
