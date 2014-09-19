using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneratorHelpers
{
    public class SapUI5Project
    {
        public string Name { get;set; }
        public List<SapUI5Library> Libraries { get; set; }
        public SapUI5ProjectType Type { get; set; }
        public IView View { get; set; }
    }
}
