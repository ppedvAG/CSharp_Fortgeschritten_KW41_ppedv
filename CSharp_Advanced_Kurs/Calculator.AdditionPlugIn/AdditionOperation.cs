using Calculator.PluginBase;

namespace Calculator.AdditionPlugIn
{
    public class AdditionOperation : ICalculatorPlugIn
    {
        public string Name { get; set; } = "Addition";
        public string OperatorDescription { get; set; } = "+";

        public double Operation(double a, double b)
        {
            return a + b;
        }
    }
}