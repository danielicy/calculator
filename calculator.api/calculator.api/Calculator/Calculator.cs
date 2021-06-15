using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace calculator.api
{   
        public class Calculator
        {

        Dictionary<char, int> operatorPresedence = new Dictionary<char, int>();

        public Calculator()
        {
            operatorPresedence['+'] = 1;
            operatorPresedence['-'] = 1;
            operatorPresedence['*'] = 2;
            operatorPresedence['/'] = 2;
        }

            public double Calculate(string expression)
            {
                // Remove all spaces
                expression = Regex.Replace(expression, @"\s+", "");

           
            return Solve(expression);
            }

        private double Solve(string expression)
        {
            //1+8+7*4/2+5*2.5 = 9 + 14 + 12.5

            string buffer = "";
           
            Queue<string> results = new Queue<string>();
            Stack<char> operators = new Stack<char>();
            Stack<double> tempStack = new Stack<double>();

            foreach (char c in expression)
            {
                if (char.IsDigit(c) || c == '.')
                    buffer += c;
                else if ("+-*/".Contains(c))
                {
                    results.Enqueue(buffer);
                    buffer = "";

                    if (operators.Count == 0)
                        operators.Push(c);
                    else if (operatorPresedence[c] > operatorPresedence[operators.Peek()])
                    {
                        operators.Push(c);
                    }
                    else if (operatorPresedence[c] == operatorPresedence[operators.Peek()])
                    {
                        results.Enqueue(operators.Pop().ToString());
                        operators.Push(c);
                    }
                    else if (operatorPresedence[c] < operatorPresedence[operators.Peek()])
                    {
                        results.Enqueue(operators.Pop().ToString());

                        operators.Push(c);
                    }

                }
                else
                    throw new Exception("Invalid character in string");
            }
            results.Enqueue(buffer);

            while (operators.Count > 0)
            {
                results.Enqueue(operators.Pop().ToString());
            }

           
            while (results.Count > 0)
            {
                string tmp = results.Dequeue();

                if ("+-*/".Contains(tmp))
                {
                    double t1 = tempStack.Pop();
                    double t2 = tempStack.Pop();
                    double total = operation( t2, t1, tmp);
                    tempStack.Push(total);
                }
                else
                    tempStack.Push(double.Parse(tmp)); 
            }

            return tempStack.Pop();
        }

        private double operation(double v1, double v2, string op)
        {
            switch(op)
            {
                case "+":
                    return v1 + v2;
                case "-":
                    return v1 - v2;
                case "*":
                    return v1 * v2;
                case "/":
                    return v1 / v2;
                default:
                    throw new Exception("Ilegal character");

            }
        }
    }
     
    
}
