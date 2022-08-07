using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsLegend : EchartsPropertyBase
    {
        public string top { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(top, nameof(top)) +
                   $"}}\n";
        }
    }
}
