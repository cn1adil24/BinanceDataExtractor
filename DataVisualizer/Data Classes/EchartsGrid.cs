namespace DataVisualizer
{
    class EchartsGrid : EchartsPropertyBase
    {
        public string bottom { get; set; }

        public string top { get; set; }

        public override string ToString()
        {
            return $"{{\n" +
                   AddProperty(bottom, nameof(bottom)) +
                   AddProperty(top, nameof(top)) +
                   $"}}\n";
        }
    }
}
