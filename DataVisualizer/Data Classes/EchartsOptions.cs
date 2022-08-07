using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsOptions : EchartsPropertyBase
    {
        public EchartsTitle[] title { get; set; }

        public EchartsTooltip tooltip { get; set; }

        public EchartsLegend legend { get; set; }

        public EchartsDataZoom[] dataZoom { get; set; }

        public EchartsAxis[] xAxis { get; set; }

        public EchartsAxis[] yAxis { get; set; }

        public EchartsGrid[] grid { get; set; }

        public string[] color { get; set; }

        public EchartsSeries[] series { get; set; }

        public override string ToString()
        {
            return $"option = {{\n" +
                   AddProperty(title, nameof(title)) +
                   AddProperty(tooltip, nameof(tooltip)) +
                   AddProperty(legend, nameof(legend)) +
                   AddProperty(dataZoom, nameof(dataZoom)) +
                   AddProperty(xAxis, nameof(xAxis)) +
                   AddProperty(yAxis, nameof(yAxis)) +
                   AddProperty(grid, nameof(grid)) +
                   AddProperty(color, nameof(color)) +
                   AddProperty(series, nameof(series)) +
                   $"}};\n";
        }
    }
}
