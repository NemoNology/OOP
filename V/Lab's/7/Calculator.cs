using System;
using System.Collections.Generic;

namespace OOP__IV__Lab_7_WF
{
    class Calculator
    {
        private static Stack<string> operations = new Stack<string>();
        private static Stack<double> operands = new Stack<double>();

        public static double PopOperand()
        {
            return operands.Pop();
        }

        public static string PopOperation()
        {
            return operations.Pop();
        }

        public static void Push(double element)
        {
            operands.Push(element);
        }
        public static void Calculate()
        {
            if (operations.Peek() == "(")
            {
                return;
            }

            if (Operation.IsOneOperandOperation(operations.Peek()))
            {
                Push(Operation.Calculate(PopOperation(), PopOperand()));
            }
            else
            {
                double operand2 = PopOperand();
                Push(Operation.Calculate(PopOperation(), PopOperand(), operand2));
            }
        }

        public static void Push(string element)
        {
            if (element == ")")
            {
                while (operations.Peek() != "(")
                {
                    Calculate();
                }

                // Pop "("
                PopOperation();
                return;
            }
            else if (element == "(" || operations.Count == 0)
            {
                operations.Push(element);
                return;
            }
            else if (Operation.GetOperationPriority(element) <= Operation.GetOperationPriority(operations.Peek()))
            {
                Calculate();
            }

            operations.Push(element);
        }

        public static void ChangeTopOperandValue(double newValue)
        {
            operands.Pop();
            operands.Push(newValue);
        }

        public static double GetAnswer()
        {
            while (operations.Count != 0)
            {
                Calculate();
            }

            return operands.Peek();
        }

        public static void Clear()
        {
            while (operations.Count != 0)
            {
                operations.Pop();
            }

            while (operands.Count != 0)
            {
                operands.Pop();
            }
        }

        public static double GetTopOperand()
        {
            return operands.Peek();
        }

        public static string GetTopOperation()
        {
            return operations.Peek();
        }

        // expression have to be seppareted with ' '
        public static void SetExpression(string expression)
        {
            string[] buffer = expression.Trim(' ').Split(' ');

            Clear();

            foreach (string s in buffer)
            {
                try
                {
                    Push(Convert.ToDouble(s));
                }
                catch
                {
                    Push(s);
                }
            }
        }

    }
}
