using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsVariable
    {
        public EchartsVariable(string name)
        {
            this.name = name;
        }

        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
