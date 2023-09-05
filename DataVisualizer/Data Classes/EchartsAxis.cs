namespace DataVisualizer
{
    class EchartsAxis : EchartsPropertyBase
    {
        public EchartsVariable data { get; set; }

        public int gridIndex { get; set; }

        public EchartsBoolean scale { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(data, nameof(data)) +
                   AddProperty(gridIndex, nameof(gridIndex)) +
                   AddProperty(scale, nameof(scale)) +
                   $"}}\n";
        }
    }
}
