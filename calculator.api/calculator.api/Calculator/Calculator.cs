using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator.api.Calculator
{

    public class Calculator
    {
        //5 + 10 * 3
        public static string Calculate(Expression expression)
        {


            Stack<string> operationsQ = new Stack<string>();
            Stack<double> operatorsQ = new Stack<double>();

            double? total = null;
            double? buffer1 = null;

            double tmp;
            int cnt = 0;

            string operation = "";
            foreach (var n in expression.Operators)
            {
                tmp = double.Parse(n);

                if (cnt < expression.Operations.Count())
                    operation = expression.Operations[cnt];
                else
                {
                    operatorsQ.Push(tmp);
                    buffer1 = CalculateBuffer(operationsQ, operatorsQ);
                    total = Arthmetic(total, buffer1, operationsQ.Pop());

                }

                if (operation == "+" || operation == "-")
                {
                    if (operatorsQ.Count > 0)
                    {
                        operatorsQ.Push(tmp);
                        buffer1 = CalculateBuffer(operationsQ, operatorsQ);
                        total = Arthmetic(total, buffer1, operationsQ.Pop());
                        buffer1 = null;

                    }
                    else if (buffer1 == null)
                    {
                        buffer1 = tmp;
                    }
                    else if (buffer1 != null)
                    {
                        total = Arthmetic(buffer1, tmp, operationsQ.Pop());

                        buffer1 = null;
                    }

                    operationsQ.Push(operation);

                }
                else if (operation == "*" || operation == "/")
                {
                    operationsQ.Push(operation);
                    operatorsQ.Push(tmp);
                }
                cnt++;

            }

            return total.ToString();
        }

        static double? CalculateBuffer(Stack<string> operations, Stack<double> operators)
        {
            double? buffer = operators.Pop();

            while (operators.Count > 0)
            {
                buffer = Arthmetic(operators.Pop(), buffer, operations.Pop());
            }

            return buffer;
        }

        private static double? Arthmetic(double? buffer1, double? buffer2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return buffer1 + buffer2;
                case "-":
                    return buffer1 - buffer2;
                case "*":
                    return buffer1 * buffer2;
                case "/":
                    return buffer1 / buffer2;

            }
            if (operation == "*")
                return buffer1 * buffer2;
            else if (operation == "/")
                return buffer1 / buffer2;
            else
                throw new Exception($"Invalid operation {operation}");
        }
    }


}
