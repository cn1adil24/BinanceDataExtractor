using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsTooltip : EchartsPropertyBase
    {
        public EchartsAxisTrigger trigger { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(trigger, nameof(trigger)) +
                   $"}}\n";
        }
    }
}
