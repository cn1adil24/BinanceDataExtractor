using DataManipulator;
using System.IO;

namespace DataVisualizer
{
    public partial class EchartsForm : FormBase
    {
        private EchartsLineRenderer Renderer;

        public EchartsForm(DelimitedHandler delimitedHandler) : base(delimitedHandler)
        {
            InitializeComponent();

            DelimitedHandler = delimitedHandler;
            Renderer = new EchartsLineRenderer();

            Visualize();
        }

        protected override void ApplyChanges()
        {
            webBrowser1.DocumentText = "";
            Renderer = new EchartsLineRenderer();
            Visualize();
        }

        public void Visualize()
        {
            CreateHTML();
            RenderGraph();
            SaveHTML();
        }

        private void CreateHTML()
        {
            Embed("Close time", "dateList");
            Embed("EMA12", "EMA12List");
            Embed("EMA26", "EMA26List");
            Embed("RSI", "RSIList");

            void Embed(string columnName, string variableName)
            {
                Renderer.StartEmbedding(variableName);

                foreach (var value in GetValues(columnName))
                    Renderer.Embed(value);

                Renderer.StopEmbedding();
            }
        }

        private void RenderGraph()
        {
            webBrowser1.DocumentText = Renderer.GetHTML();
        }

        private void SaveHTML()
        {
            string filePath = "C:/Binance/Graph.html";
            File.WriteAllText(filePath, Renderer.GetHTML());
        }
    }
}
