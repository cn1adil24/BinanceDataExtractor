using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                xAxis = new EchartsAxis[]
                {
                    new EchartsAxis() { data = new EchartsVariable("dateList") },
                    new EchartsAxis() { data = new EchartsVariable("dateList"), gridIndex = 1 }
                },
                dataZoom = new EchartsDataZoom
                {
                    xAxisIndex = new int[2] { 0, 1 }
                },
                yAxis = new EchartsAxis[]
                {
                    new EchartsAxis(),
                    new EchartsAxis() { gridIndex = 1 }
                },
                grid = new EchartsGrid[]
                {
                    new EchartsGrid() { bottom = "60%" },
                    new EchartsGrid() { top = "60%" }
                },
                series = new EchartsSeries[]
                {
                    new EchartsSeries()
                    {
                        type = EchartsSeriesType.line,
                        showSymbol = new EchartsBoolean(false),
                        data = new EchartsVariable("EMA12List"),
                        connectNulls = new EchartsBoolean(true),
                        smooth = new EchartsBoolean(true)
                    },
                    new EchartsSeries()
                    {
                        type = EchartsSeriesType.line,
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
