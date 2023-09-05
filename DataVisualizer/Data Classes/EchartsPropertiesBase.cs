using System.Collections;
using System.Collections.Generic;

namespace DataVisualizer
{
    class EchartsPropertyBase
    {
        protected string AddProperty(object property, string propertyName)
        {
            if (property != null)
            {
                if (IsArray(property))
                    return $"   {propertyName}: [{string.Join(",", ConvertToArray(property as IEnumerable))}],\n";
                else if (CanEnquote(property))
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

        private object[] ConvertToArray(IEnumerable array)
        {
            List<object> elements = new List<object>();
            foreach (object element in array)
            {
                if (CanEnquote(element))
                    elements.Add($"'{element}'");
                else
                    elements.Add(element);
            }
            return elements.ToArray();
        }

        private bool IsArray(object property) => property.GetType().IsArray;
    }
}
