using System.Text;

namespace DataVisualizer
{
    abstract class EchartsRendererBase
    {
        public StringBuilder HTMLBuilder { get; protected set; } = new StringBuilder();

        public virtual string GetHTML()
        {
            return GetInitialCode() + "\n" +
                   GetVariables() + "\n" +
                   GetPlotOptions() + "\n" +
                   GetClosingCode();
        }

        protected string GetInitialCode()
        {
            return "<!DOCTYPE html>\n" +
                   "<html lang=\"en\" style=\"height: 100%\">\n" +
                   "<head>\n" +
                   "    <meta charset=\"utf-8\">\n" +
                   "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\" />\n" +
                   "</head>\n" +
                   "<body style=\"height: 100%; margin: 0\">\n" +
                   "    <div id=\"container\" style=\"height: 100%\"></div>\n" +
                   "    <script type=\"text/javascript\" src=\"https://fastly.jsdelivr.net/npm/echarts@5.3.3/dist/echarts.min.js\"></script>\n" +
                   "    <script type=\"text/javascript\">\n" +
                   "    var dom = document.getElementById('container');\n" +
                   "    var myChart = echarts.init(dom, null, {\n" +
                   "        renderer: 'canvas',\n" +
                   "        useDirtyRect: false\n" +
                   "    });\n" +
                   "    var app = {};\n" +
                   "    var option;\n";
        }

        protected string GetClosingCode()
        {
            return "    if (option && typeof option === 'object') {\n" +
                   "        myChart.setOption(option);\n" +
                   "    }\n" +
                   "    window.addEventListener('resize', myChart.resize);\n" +
                   "</script>\n" +
                   "</body>\n" +
                   "</html>\n";
        }

        protected virtual string GetVariables() => string.Empty;

        protected abstract string GetPlotOptions();
    }
}
