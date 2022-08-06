using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsDataZoom : EchartsPropertyBase
    {
        public int[] xAxisIndex { get; set; }

        public string type { get; set; } = "slider";

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(type, nameof(type)) +
                   $"   {nameof(xAxisIndex)}: [{string.Join(",", xAxisIndex.AsEnumerable())}]" +
                   $"}}\n";
        }
    }
}
