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
