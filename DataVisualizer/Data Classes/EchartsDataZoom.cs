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

        public EchartsDataZoomType type { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(type, nameof(type)) +
                   AddProperty(xAxisIndex, nameof(xAxisIndex)) +
                   $"}}\n";
        }
    }
}
