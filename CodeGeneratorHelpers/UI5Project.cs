using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneratorHelpers
{
    public class UI5Project
    {
        public string Name { get;set; }
        public List<UI5Library> Libraries { get; set; }
        public UI5ProjectType Type { get; set; }
        public IView View { get; set; }
    }
}
