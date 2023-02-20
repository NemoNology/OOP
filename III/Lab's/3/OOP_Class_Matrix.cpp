#include <iostream>
#include "Matrix.h"


using namespace std;







int main()
{
	setlocale(LC_ALL, "Russian");



	srand(time(nullptr));

	int n = 6;

	Matrix mat;

	for (int i = 0; i < n; i++) {

		mat.Random_Matrix();

		mat.Show_Matrix();

	}

	system("pause");
	return 0;

}
