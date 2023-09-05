namespace DataVisualizer
{
    class EchartsLegend : EchartsPropertyBase
    {
        public string top { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(top, nameof(top)) +
                   $"}}\n";
        }
    }
}
