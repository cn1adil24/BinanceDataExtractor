using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsAxis : EchartsPropertyBase
    {
        public EchartsVariable data { get; set; }

        public int gridIndex { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(data, nameof(data)) +
                   AddProperty(gridIndex, nameof(gridIndex)) +
                   $"}}\n";
        }
    }
}
