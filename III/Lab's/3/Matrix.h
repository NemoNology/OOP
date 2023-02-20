#pragma once
#include <iostream>
#include <vector>
#include <exception>
#include <iomanip>


using namespace std;


class Matrix
{

private:

	// Матрица в виде вектора векторов типа double
	vector<vector<double>> Matr;

	//// Одномерная матрица в виде вектора типа double
	//vector<double> Matr1D;

public:



	// Изменение кол-ва строк матрицы
	void Set_aLines(const unsigned int new_size);


	// Изменение кол-ва столбцов матрицы
	void Set_aRows(const unsigned int new_size);


	// Получение кол-ва строк матрицы
	unsigned int Get_aLines();


	// Получение кол-ва столбцов матрицы
	unsigned int Get_aRows();


	// Вывод матрицы на консоль
	void Show_Matrix();


	// Функция получения строки матрицы
	vector<double> Get_Line(const unsigned int line_number);


	// Функция получения столбца матрицы
	vector<double> Get_Row(const unsigned int row_number);


	// Функция получения определённого элемента
	double Get_element(unsigned int line, unsigned int row);


	// Заполнение матрицы одним значением
	void Fill_Matrix(double value);


	// Заполнение матрицы случайными значениями
	void Random_Matrix();


};


