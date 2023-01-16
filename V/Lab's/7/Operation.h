#pragma once
#include <vector>
#include <string>

using namespace std;

// x ^ y, sqrt(x)
// sin(x), cos(x), tan(x), ln(x), exp(x)
// x * y, x / y
// x - y, x + y

//vector<vector<string>> operations = {
//			{ "^", "sqrt" },
//			{ "sin", "cos", "tan", "ln", "exp" },
//			{ "*", "/" },
//			{ "+", "-" } };

const vector<string> priorities = { "+-", "*/","sincostanlnexp", "^sqrt" };

vector<string> OneOperandOperation = { "sqrt", "sin", "cos", "tan", "ln", "exp" };

class Operation
{
public:

	// O - Operand
	static double Calculate(string operation, double O1, double O2)
	{
		if (operation == "^")
		{
			return pow(O1, O2);
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

		if (operation == "-")
		{
			return O1 - O2;
		}

		return 0;
	}

	// O - Operand
	static double Calculate(string operation, double O, bool IsDegree = false)
	{
		if (operation == "sqrt")
		{
			return sqrt(O);
		}

		if (operation == "ln")
		{
			return log(O);
		}

		if (operation == "exp")
		{
			return exp(O);
		}

		// Converting in Degree
		if (IsDegree)
		{
			O *= atan(1) / 45;
		}

		if (operation == "sin")
		{
			return sin(O);
		}

		if (operation == "cos")
		{
			return cos(O);
		}

		if (operation == "tan")
		{
			return tan(O);
		}

		return 0;
	}

	static bool IsOneOperandOperation(string operation)
	{
		for (size_t i = 0; i < OneOperandOperation.size(); i++)
		{
			if (OneOperandOperation[i] == operation)
			{
				return true;
			}
		}

		return false;
	}

	static int GetOperationPriority(string operation)
	{
		for (size_t i = 0; i < priorities.size(); i++)
		{
			if (priorities[i].find(operation) != -1)
			{
				return i + 1;
			}
		}

		return 0;
	}


};

