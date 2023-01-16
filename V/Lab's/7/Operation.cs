using System;

namespace OOP__IV__Lab_7_WF
{
    class Operation
    {
        public static string[] priorities = { "+m", "*/", "sincostanlnexp", "^sqrt" };

		public static string[] oneOperandOperations = { "sqrt", "sin", "cos", "tan", "ln", "exp" };

		/// <summary>
		/// O - Operand
		/// </summary>
		public static double Calculate(string operation, double O1, double O2)
        {
			if (operation == "^")
			{
				return Math.Pow(O1, O2);
			}

			if (operation == "*")
			{
				return O1 * O2;
			}

			if (operation == "/")
			{
				return O1 / O2;
			}

			if (operation == "+")
			{
				return O1 + O2;
			}

			if (operation == "m")
			{
				return O1 - O2;
			}

			return 0;
		}

		/// <summary>
		/// O - Operand
		/// </summary>
		public static double Calculate(string operation, double O, bool IsDegree = false)
        {
			if (operation == "sqrt")
			{
				return Math.Sqrt(O);
			}

			if (operation == "ln")
			{
				return Math.Log(O);
			}

			if (operation == "exp")
			{
				return Math.Exp(O);
			}

			// Converting in Degree
			if (IsDegree)
			{
				O *= Math.Atan(1) / 45;
			}

			if (operation == "sin")
			{
				return Math.Sin(O);
			}

			if (operation == "cos")
			{
				return Math.Cos(O);
			}

			if (operation == "tan")
			{
				return Math.Tan(O);
			}

			return 0;
		}

		public static bool IsOneOperandOperation(string operation)
		{
			foreach(string s in oneOperandOperations)
			{
				if (s == operation)
				{
					return true;
				}
			}

			return false;
		}

		public static int GetOperationPriority(string operation)
		{
			for (int i = 0; i < priorities.Length; i++)
			{
				if (priorities[i].IndexOf(operation) != -1)
				{
					return i + 1;
				}
			}

			return 0;
		}

	}
}
