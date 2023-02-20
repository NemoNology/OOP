#include <iostream>

using namespace std;

// Не смог вновь использовать M_PI, т.к. не нашёл его
const double PI = 3.141592653589793; 

// Расчёт а и b
void Calc_a(float &x, float &y, float &a) {
	a = (2 * cos(x - (PI / 6))) / (0.5 + pow(sin(y), 2));
	cout << endl; // Небольшой отступ для комфортного прочтения результатов (НОД)
	cout << endl;
	cout << "a = " << a << endl;
	cout << endl;
}
void Calc_b(float& z, float &b) {
	b = 1 + (pow(z, 2)) / (3 + (pow(z, 2) / 5));
	cout << "b = " << b << endl;
	cout << endl; // (НОД)
	cout << endl;
}


// Создание случайного одномерного массива (int)
void Cr_rand_1darr(int* arr, unsigned &n) {
	for (unsigned i = 0; i < n; i++) {
		arr[i] = rand() % 200 - 100;
	}
 }

// Вывод массива
void Cout_1darr(int* arr, unsigned& n) {
	for (unsigned i = 0; i < n; i++) {
		cout << arr[i] << "; ";
	}
	cout << endl;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	float a, b, x, y, z; float* ap = &a, * bp = &b;
	unsigned n = 10, restart; unsigned* np = &n;


// Массив - 2-ое задание 
// ################################################

	int *arr = new int[n];

	Cr_rand_1darr(arr, n);
	Cout_1darr(arr, n);

// ################################################

// Вычисление по 1-ому заданию
Beginning: 
	cout << endl; // (НОД)
	cout << endl;
	cout << "Введите x, y, z поочерёдно, через Enter:" << endl;
	cin >> x >> y >> z;
	Calc_a(x, y, *ap);
	Calc_b(z, *bp);
	cout << "Хотите изменить значения? (1 - да; 0 - нет)" << endl;
	cout << endl; // (НОД)
	cin >> restart;
	if (restart == 1) { // Возможность ввода других значений
		goto Beginning;
	}
	else {
		cout << endl; // (НОД)
		cout << endl;
		cout << "### Если Вы ввели некорректные значения для x, y или z, программа моментально завершится ###" << endl;
		cout << "### Попытайтесь вновь, если Вам нужны результаты этой программы ###" << endl;
		cout << endl;
		cout << endl;
		system("pause");
		return 0;
	}
}