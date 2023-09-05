using System;
using TechnicalAnalysis;

namespace TestProject
{
    class RSITestClass
    {
        public void TestMethod(double[] points)
        {
            RSICalculator calculatorWithSmoothing = new RSICalculator(14, "RSI", true);
            foreach (var point in points)
            {
                calculatorWithSmoothing.AddDataPoint(point);
                Console.WriteLine($"RSI: {calculatorWithSmoothing.Result}");
            }

            RSICalculator calculator = new RSICalculator(14, "RSI", false);
            foreach (var point in points)
            {
                calculator.AddDataPoint(point);
                Console.WriteLine($"RSI: {calculator.Result}");
            }
        }
    }
}
