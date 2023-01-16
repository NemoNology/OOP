#pragma once
#include "Operation.h"
#include <vector>
#include <string>
#include <sstream>

using namespace std;

vector<string> operations;
vector<double> operands;

class Calculator
{
public:

	static double PopOperand()
	{
		double res = operands.back();
		operands.pop_back();
		return res;
	}

	static string PopOperation()
	{
		string res = operations.back();
		operations.pop_back();
		return res;
	}

	static void Push(double element)
	{	
		operands.push_back(element);
	}

	static void Calculate()
	{
		if (operations.back() == "(")
		{
			return;
		}

		if (Operation::IsOneOperandOperation(operations.back()))
		{
			Push(Operation::Calculate(PopOperation(), PopOperand()));
		}
		else
		{
			double operand2 = PopOperand();
			Push(Operation::Calculate(PopOperation(), PopOperand(), operand2));
		}
	}

	static void Push(string element)
	{
		if (element == ")")
		{
			while (operations.back() != "(")
			{
				Calculate();
			}

			// Pop "("
			PopOperation();
			return;
		}
		else if (element == "(" || operations.empty())
		{
			operations.push_back(element);
			return;
		}
		else if (Operation::GetOperationPriority(element) <= Operation::GetOperationPriority(operations.back()))
		{
			Calculate();
		}

		operations.push_back(element);
	}

	static void ChangeTopOperandValue(double newValue)
	{
		operands[operands.size() - 1] = newValue;
	}

	static double GetAnswer()
	{
		while (!operations.empty())
		{
			Calculate();
		}

		return operands.back();
	}

	static void Clear()
	{
		while (!operations.empty())
		{
			operations.pop_back();
		}

		while (!operands.empty())
		{
			operands.pop_back();
		}
	}

	static double GetTopOperand()
	{
		return operands.back();
	}

	static string GetTopOperation()
	{
		return operations.back();
	}

	// expression have to be seppareted with ' '
	static void SetExpression(string expression)
	{
		vector<string> test;
		stringstream ss(expression);
		string temp;

		while (getline(ss, temp, ' '))
		{
			test.push_back(temp);
		}

		for (size_t i = 0; i < test.size(); i++)
		{
			try {
				Push(stod(test[i]));
			}
			catch (exception)
			{
				Push(test[i]);
			}
		}
	}

};

