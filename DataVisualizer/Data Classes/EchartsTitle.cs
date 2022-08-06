using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsTitle : EchartsPropertyBase
    {
        public string text { get; set; }

        public string left { get; set; }

        public string top { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(top, nameof(top)) +
                   AddProperty(left, nameof(left)) +
                   AddProperty(text, nameof(text)) +
                   $"}}\n";
        }
    }
}
