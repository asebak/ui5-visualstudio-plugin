using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneratorHelpers
{
    public class Index
    {
        public static string createContentFromT4(SapUI5ProjectType type, string viewExtension, string mainControllerName)
        {
            var jsonTemplate = new T4.Index
            {
                Session =
                    new Dictionary<string, object>
                    {
                        {"ControllerName", mainControllerName},
                        {"IsMobile", type == SapUI5ProjectType.Mobile},
                        {"ViewExtension", viewExtension}
                    }
            };
            jsonTemplate.Initialize();
            return jsonTemplate.TransformText();
        }
    }
}
