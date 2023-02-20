#include <iostream>
#include <vector>
#include <exception>
#include <iomanip>
#include "Matrix.h"


using namespace std;

Matrix::Matrix() {


}



// Изменение кол-ва строк матрицы
void Matrix::Set_aLines(const unsigned int new_size) {


	if (new_size == 0) {

		throw invalid_argument("Введено нулевое значение!");

	}
	else {

		this->Matr.resize(new_size);

	}


}


// Изменение кол-ва столбцов матрицы
void Matrix::Set_aRows(const unsigned int new_size) {


	if (new_size == 0) {

		throw invalid_argument("Введено нулевое значение!");

	}
	else {

		for (unsigned short i = 0; i < this->Matr.size(); i++) {

			this->Matr[i].resize(new_size);

		}

	}

}


// Получение кол-ва строк матрицы
unsigned int Matrix::Get_aLines() {

	return this->Matr.size();

};


// Получение кол-ва столбцов матрицы
unsigned int Matrix::Get_aRows() {

	return this->Matr[0].size();

}


// Вывод матрицы в консоль
void Matrix::Show_Matrix() {

	cout << "Matrix:\n";

	for (unsigned short i = 0; i < this->Get_aLines(); i++) {

		cout << "\t";

		for (unsigned short j = 0; j < this->Get_aRows(); j++) {

			cout << setw(14) << setprecision(8) << this->Matr[i][j];

		}

		cout << "\n";

	}

	cout << "\n";

}


// Функция получения строки матрицы
vector<double> Matrix::Get_Line(const unsigned int line_number) {

	vector<double> result;							// Результирующий вектор - возвращаемая строка


	if (line_number == 0) {

		throw invalid_argument("Некорректный номер строки!");

	}
	else {

		for (unsigned short j = 0; j < this->Get_aRows(); j++) {

			result[j] = this->Matr[line_number - 1][j];

		}

		return result;

	}
}


// Функция получения столбца матрицы
vector<double> Matrix::Get_Row(const unsigned int row_number) {

	vector<double> result;							// Результирующий вектор - возвращаемый столбец

	if (row_number == 0) {

		throw invalid_argument("Некорректный номер столбца!");

	}
	else {

		for (unsigned short i = 0; i < this->Get_aLines(); i++) {

			result[i] = this->Matr[i][row_number - 1];

		}

		return result;

	}

}


// Функция получения определённого элемента
double Matrix::Get_element(unsigned int line, unsigned int row) {

	if ((line == 0) || (row == 0)) {

		throw invalid_argument("Некорректный адрес элемента!");

	}
	else {

		return this->Matr[line][row];

	}

}


// Заполнение матрицы одним значением
void Matrix::Fill_Matrix(double value) {

	for (unsigned short i = 0; i < this->Get_aLines(); i++) {

		for (unsigned short j = 0; j < this->Get_aRows(); j++) {

			this->Matr[i][j] = value;

		}

	}

}


// Заполнение матрицы случайными значениями
void Matrix::Random_Matrix() {

	for (unsigned short i = 0; i < this->Get_aLines(); i++) {

		for (unsigned short j = 0; j < this->Get_aRows(); j++) {

			this->Matr[i][j] = rand() % 200 - 100 * 0.1;

		}

	}

}