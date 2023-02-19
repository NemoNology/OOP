using System;
using System.Collections.Generic;

namespace Tests.Models.Calculator
{
    /// <summary>
    /// Class calculator <br/>
    /// Creator: NemoNology
    /// </summary>
    class Calculator
    {
        /// <summary>
        /// Stack that keep all operations
        /// </summary>
        private static Stack<string> operations = new Stack<string>();
        /// <summary>
        /// Stack that keep all operands
        /// </summary>
        private static Stack<double> operands = new Stack<double>();

        /// <summary>
        /// Pop top operand from stack
        /// </summary>
        /// <returns> Poped operand (double) </returns>
        public static double PopOperand()
        {
            return operands.Pop();
        }

        /// <summary>
        /// Pop top operation from stack
        /// </summary>
        /// <returns> Poped operation (string) </returns>
        public static string PopOperation()
        {
            return operations.Pop();
        }

        /// <summary>
        /// Push operand to stack top
        /// </summary>
        public static void Push(double element)
        {
            operands.Push(element);
        }

        /// <summary>
        /// Take top operation and top oprerand(s) and calclulate it with popping tokken operand(s) and operation
        /// </summary>
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

        /// <summary>
        /// Push operation to stack top <i> and calculating, if it's nessesary </i>
        /// </summary>
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

        /// <summary>
        /// Calculating while operations stack is not empty
        /// </summary>
        /// <returns>  Calculated result, that keeps in operands stack (at the top)  </returns>
        public static double GetAnswer()
        {
            while (operations.Count != 0)
            {
                Calculate();
            }

            return operands.Peek();
        }

        /// <summary>
        /// Clear operation and operands stacks
        /// </summary>
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

        /// <returns>  Operand at the stack top  </returns>
        public static double TopOperand
        {
            get
            {
                return operands.Peek();
            }
        }

        /// <returns>  Operation at the stack top  </returns>
        public static string TopOperation
        {
            get
            {
                return operations.Peek();
            }
        }

        /// <summary>
        /// 
        ///     Load full expression to stacks
        /// 
        /// </summary>
        /// <value>  <b> Inputed expression need to be separated with separator </b>  </value>  
        public static void SetExpression(string expression, char separator = ' ')
        {
            string[] buffer = expression.Trim(separator).Split(separator);

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
