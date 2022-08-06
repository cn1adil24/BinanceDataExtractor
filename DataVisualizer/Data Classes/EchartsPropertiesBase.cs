using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVisualizer
{
    class EchartsPropertyBase
    {
        protected string AddProperty(object property, string propertyName)
        {
            if (property != null)
            {
                if (CanEnquote(property))
                    return $"   {propertyName}: '{property}',\n";
                else
                    return $"   {propertyName}: {property},\n";
            }
            else
                return $"";
        }

        private bool CanEnquote(object property)
        {
            return property.GetType() == typeof(string) || property.GetType().IsEnum;
        }
    }
}
