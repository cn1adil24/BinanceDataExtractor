using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsOptions
    {
        public EchartsTitle[] title { get; set; }

        public EchartsTooltip tooltip { get; set; }

        public EchartsLegend legend { get; set; }

        public EchartsDataZoom[] dataZoom { get; set; }

        public EchartsAxis[] xAxis { get; set; }

        public EchartsAxis[] yAxis { get; set; }

        public EchartsGrid[] grid { get; set; }

        public EchartsSeries[] series { get; set; }

        public override string ToString()
        {
            return $"option = {{\n" +
                   $"   {nameof(title)}: [" +
                   $"       {string.Join(",", title.AsEnumerable())}" +
                   $"   ],\n" +
                   $"   {nameof(tooltip)}: {tooltip},\n" +
                   $"   {nameof(legend)}: {legend},\n" +
                   $"   {nameof(dataZoom)}: [" +
                   $"       {string.Join(",", dataZoom.AsEnumerable())}" +
                   $"   ],\n" +
                   $"   {nameof(xAxis)}: [" +
                   $"       {string.Join(",", xAxis.AsEnumerable())}" +
                   $"   ],\n" +
                   $"   {nameof(yAxis)}: [" +
                   $"       {string.Join(",", yAxis.AsEnumerable())}" +
                   $"   ],\n" +
                   $"   {nameof(grid)}: [" +
                   $"       {string.Join(",", grid.AsEnumerable())}" +
                   $"   ],\n" +
                   $"   {nameof(series)}: [" +
                   $"       {string.Join(",", series.AsEnumerable())}" +
                   $"   ]\n" +
                   $"}};\n";
        }
    }
}
