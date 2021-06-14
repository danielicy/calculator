using System;
using System.Text.RegularExpressions;


namespace calculator.api
{   
        public class Calculator
        {
            public double Calculate(string expression)
            {
                // Remove all spaces
                expression = Regex.Replace(expression, @"\s+", "");

                Operation operation = new Operation();
                operation.Parse(expression);

                double result = operation.Solve();

                return result;
            }
        }

        public class Operation
        {
            public Operation LeftOperator { get; set; }
            public string Operator { get; set; }
            public Operation RightOperator { get; set; }

            private Regex additionSubtraction = new Regex("[+-]", RegexOptions.RightToLeft);
            private Regex multiplicationDivision = new Regex("[*/]", RegexOptions.RightToLeft);

            public void Parse(string equation)
            {
                var operatorLocation = additionSubtraction.Match(equation);
                if (!operatorLocation.Success)
                {
                    operatorLocation = multiplicationDivision.Match(equation);
                }

                if (operatorLocation.Success)
                {
                    Operator = operatorLocation.Value;

                    LeftOperator = new Operation();
                    LeftOperator.Parse(equation.Substring(0, operatorLocation.Index));

                    RightOperator = new Operation();
                    RightOperator.Parse(equation.Substring(operatorLocation.Index + 1));
                }
                else
                {
                    Operator = "v";
                    result = double.Parse(equation);
                }
            }

            private double result;

            public double Solve()
            {
                switch (Operator)
                {
                    case "v":
                        break;
                    case "+":
                        result = LeftOperator.Solve() + RightOperator.Solve();
                        break;
                    case "-":
                        result = LeftOperator.Solve() - RightOperator.Solve();
                        break;
                    case "*":
                        result = LeftOperator.Solve() * RightOperator.Solve();
                        break;
                    case "/":
                        result = LeftOperator.Solve() / RightOperator.Solve();
                        break;
                    default:
                        throw new Exception("Call Parse first.");
                }

                return result;
            }
        }
    
}
