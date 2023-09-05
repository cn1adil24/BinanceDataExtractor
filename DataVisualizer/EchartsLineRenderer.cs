using System.Text;

namespace DataVisualizer
{
    class EchartsLineRenderer : EchartsRendererBase, IRendersDataVariables
    {
        #region IRendersDataVariables Members

        private bool _IsEmbedding = false;

        public EchartsLineRenderer()
        {
            HTMLBuilder.Append(GetInitialCode());
        }

        public void StartEmbedding(string variableName)
        {
            _IsEmbedding = true;
            HTMLBuilder.Append($"const {variableName} = [");
        }

        public void Embed(object value)
        {
            if (_IsEmbedding == false || value is null)
                return;

            if (value.GetType() == typeof(string))
                HTMLBuilder.Append($"{Encode()},");
            else
                HTMLBuilder.Append($"{value},");

            string Encode() => $"\"{value}\"";
        }

        public void StopEmbedding()
        {
            HTMLBuilder.Append("];\n");
            _IsEmbedding = false;
        }

        #endregion

        public override string GetHTML()
        {
            if (_IsEmbedding)
                return string.Empty;

            return HTMLBuilder.ToString() +
                   GetPlotOptions() +
                   GetClosingCode();
        }

        protected override string GetPlotOptions()
        {
            StringBuilder sb = new StringBuilder();

            EchartsOptions lineOptions = CreateOptions();
            sb.Append(lineOptions);

            return sb.ToString();
        }

        private EchartsOptions CreateOptions()
        {
            return new EchartsOptions()
            {
                title = new EchartsTitle[]
                {
                    new EchartsTitle() { left = "center", text = "Exponential Moving Averages (EMA)" },
                    new EchartsTitle() { top = "55%", left = "center", text = "Relative Strength Index (RSI)" }
                },
                tooltip = new EchartsTooltip() { trigger = EchartsAxisTrigger.axis },
                legend = new EchartsLegend() { top = "3%" },
                xAxis = new EchartsAxis[]
                {
                    new EchartsAxis() { data = new EchartsVariable("dateList"), scale = new EchartsBoolean(true) },
                    new EchartsAxis() { data = new EchartsVariable("dateList"), gridIndex = 1, scale = new EchartsBoolean(true) }
                },
                dataZoom = new EchartsDataZoom[]
                {
                    new EchartsDataZoom() { xAxisIndex = new int[2] { 0, 1 }, type = EchartsDataZoomType.inside },
                    new EchartsDataZoom() { xAxisIndex = new int[2] { 0, 1 }, type = EchartsDataZoomType.slider }
                },
                yAxis = new EchartsAxis[]
                {
                    new EchartsAxis() { scale = new EchartsBoolean(true) },
                    new EchartsAxis() { gridIndex = 1, scale = new EchartsBoolean(true) }
                },
                grid = new EchartsGrid[]
                {
                    new EchartsGrid() { bottom = "60%" },
                    new EchartsGrid() { top = "60%" }
                },
                color = new string[] { "#0000ff", "#ff0000", "#fac858" },
                series = new EchartsSeries[]
                {
                    new EchartsSeries()
                    {
                        type = EchartsSeriesType.line,
                        name = "EMA12",
                        showSymbol = new EchartsBoolean(false),
                        data = new EchartsVariable("EMA12List"),
                        connectNulls = new EchartsBoolean(true),
                        smooth = new EchartsBoolean(true)
                    },
                    new EchartsSeries()
                    {
                        type = EchartsSeriesType.line,
                        name = "EMA26",
                        showSymbol = new EchartsBoolean(false),
                        data = new EchartsVariable("EMA26List"),
                        connectNulls = new EchartsBoolean(true),
                        smooth = new EchartsBoolean(true)
                    },
                    new EchartsSeries()
                    {
                        type = EchartsSeriesType.line,
                        showSymbol = new EchartsBoolean(false),
                        data = new EchartsVariable("RSIList"),
                        xAxisIndex = 1,
                        yAxisIndex = 1
                    }
                }
            };
        }
    }
}
