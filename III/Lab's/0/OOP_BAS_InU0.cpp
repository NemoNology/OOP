#include <iostream>
#include <vector> 
#include <fstream>      // Подключённые библиотеки, нужные для работы...
#include <string>
#include <exception>

#include <sstream>
#include <vector>
#include <iterator>


using namespace std;    // Для моего удобства



// #############################################################################################################


// Вывод 2Д массива на экран 
void Show_2D_Int_Vector(const vector<vector<int>> &v) {

    cout << "\n\n";

    for (unsigned i = 0; i < v.size(); i++) {
        cout << "\t";
        for (unsigned j = 0; j < v[i].size(); j++) {

            cout << v[i][j] << "\t";
        }
        cout << endl;
    }
    cout << "\n\n";

}

// Заполнение 2Д массива случайными int переменными
void Random_Fill_2D_Int_Vector(vector<vector<int>>& v) {

    for (unsigned i = 0; i < v.size(); i++) {

        v[i].resize(v.size());

        for (unsigned j = 0; j < v[i].size(); j++) {

            v[i][j] = rand() % 200 - 80;

        }
    }

}


// ... 
void Show_2D_Float_Vector(vector<vector<float>>& v) {

    cout << "\n\n";

    for (unsigned i = 0; i < v.size(); i++) {
        cout << "\t";
        for (unsigned j = 0; j < v[i].size(); j++) {

            cout << v[i][j] << "\t";
        }
        cout << endl;
    }
    cout << "\n\n";

}



// #############################################################################################################




// Запись 2Д массива в файл
void Record_2D_Int_Vector_to_File(fstream& f, const vector<vector<int>>& v) {

    f << "\n\n";

    if (!f.is_open()) {             // Если файла нет - бросаем ошибку

        throw invalid_argument("Нет файла...");

    }



    for (unsigned i = 0; i < v.size(); i++) {
        f << "\t";
        for (unsigned j = 0; j < v[i].size(); j++) {

            f << v[i][j] << "\t";
        }
        f << endl;
    }
    f << "\n\n";

    cout << "\n\t\tЗапись 2-ухмерной матрицы в файл закончено\n\n";

}

// Чтение файла
vector<vector<float>> File_Read(fstream& f, vector<vector<float>>& saving_data) {


    string line;                    // Переменная для записей строк в неё...
    unsigned short k = 0, ke = 0;

    while (getline(f, line)) { // Записываем строку из файла f в переменную line
        
        ke++;
        
    }



    if (f.is_open()) {              // Проверяем есть ли файл   
        unsigned short i=0;

        while (getline(f, line)) {  // Записываем строку из файла f в переменную line

            cout << line << endl;   // Выписываем строку...

            k = count(line.begin(), line.end(), ' ')+1;

            std::istringstream iss(line);

            //for (unsigned short i = 0; i < k + 1; i++) {

                saving_data[i].resize(k);

                for (unsigned short j = 0; j < saving_data[i].size(); j++) {

                    string buf;
                    iss >> buf;
                    float x = stof(buf);
                    saving_data[i][j] = 42/**/;

                }
            //}
                i++;

        }

    }

    else {                          // Если файла нет - бросаем ошибку
         
        throw invalid_argument("Нет файла!");   

    }



    // Уведомление для пользователя...
    cout << "\n\t\tЧтение файла окончено\n\n";

}



// #############################################################################################################



int main()
{
    setlocale(LC_ALL, "Russian");

    // Задаём размерность массива, просто потому что...
    unsigned n = 5;

    // Создаём 2Д массив
    vector<vector<int>> Vector0(n);
    vector<vector<float>> Vector1(n);


    // Заполняем данный массив
    cout << "\n\nСлучайный 2-ухмерный массив:";
    Random_Fill_2D_Int_Vector(Vector0);
    Show_2D_Int_Vector(Vector0);


    cout << "Работа с файлом:\n";
    // Создаём fstream для дальнейшей работы с файлами
    fstream F0("R:\\Array0.txt");
    fstream F1("R:\\Array1.txt");
    

   
    
    // Запись 2Д массива в файл "Array1.txt"
    try {
        Record_2D_Int_Vector_to_File(F1, Vector0);
    }
    catch (invalid_argument e) {

        cout << "\n\n\t\tФайла по указанному пути не существует!";

    }

    // Проверяем чтение\запись файла...
    try {
        File_Read(F0, Vector1);
        Show_2D_Float_Vector(Vector1);
    }
    catch (invalid_argument e) {

        cout << "\n\n\t\tФайла по указанному пути не существует!";

    }


    cout << "\n\n\n";
    system("pause"); // Делаем доп. паузу для удобства пользователя
    return 0;
}