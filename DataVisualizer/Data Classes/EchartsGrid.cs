using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsGrid : EchartsPropertyBase
    {
        public string bottom { get; set; }

        public string top { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(bottom, nameof(bottom)) +
                   AddProperty(top, nameof(top)) +
                   $"}}\n";
        }
    }
}
