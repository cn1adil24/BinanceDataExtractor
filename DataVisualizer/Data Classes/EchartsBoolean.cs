namespace DataVisualizer
{
    class EchartsBoolean
    {
        public EchartsBoolean(bool value)
        {
            this.value = value;
        }

        public bool value { get; set; }

        public override string ToString()
        {
            return value.ToString().ToLower();
        }
    }
}
