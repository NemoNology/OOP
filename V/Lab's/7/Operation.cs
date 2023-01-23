using System;

namespace OOP__IV__Lab_7_WF
{
    class Operation
    {
		/// <summary>
		///	Priorities - array that include available operations
		/// </summary>
		public static string[] priorities = { "+m", "*/", "sincostanlnexp", "^sqrt" };

		/// <summary>
		/// OneOperandOperations - array that include available operations that needs only one operand
		/// </summary>
		public static string[] oneOperandOperations = { "sqrt", "sin", "cos", "tan", "ln", "exp" };

		/// <summary>
		/// 
		///		Calculate two operands operation 
		///		
		/// </summary>
		/// <value>  O - Operand  </value>
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
		/// 
		///		Calculate one operands operation 
		///		
		/// </summary>
		/// <value>  O - Operand  </value>
		public static double Calculate(string operation, double O)
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

		/// <summary>
		///		
		///		Check if it's one operand operation
		/// 
		/// </summary>
		/// <returns>  
		/// 
		///		<c>  True  </c> - it's one operand operation <br/>
        ///		<c>  False  </c> - otherside
		/// 
		/// </returns>
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

		/// <summary>
		/// 
		///		Return Operation priority using priorities array
		/// 
		/// </summary>
		/// <param name="operation"></param>
		/// <returns>  
		///	
		///		<b> Operation priority, </b> starting with <b> 1 </b> <br/>
		///		<b> 0 </b> - if opeartion was not found	
		/// 
		/// </returns>
		/// <value>  Priorities array - array that include available operations  </value>
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
