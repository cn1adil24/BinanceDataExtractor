using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsSeries : EchartsPropertyBase
    {
        public EchartsSeriesType type { get; set; }

        public EchartsBoolean showSymbol { get; set; }

        public EchartsVariable data { get; set; }

        public EchartsBoolean connectNulls { get; set; }

        public EchartsBoolean smooth { get; set; }

        public int xAxisIndex { get; set; }

        public int yAxisIndex { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(type, nameof(type)) +
                   AddProperty(showSymbol, nameof(showSymbol)) +
                   AddProperty(data, nameof(data)) +
                   AddProperty(connectNulls, nameof(connectNulls)) +
                   AddProperty(smooth, nameof(smooth)) +
                   AddProperty(xAxisIndex, nameof(xAxisIndex)) +
                   AddProperty(yAxisIndex, nameof(yAxisIndex)) +
                   $"}}\n";
        }
    }
}
