namespace DataVisualizer
{
    class EchartsVariable
    {
        public EchartsVariable(string name)
        {
            this.name = name;
        }

        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
