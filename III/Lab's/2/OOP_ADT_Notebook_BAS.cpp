#include <iostream>
#include <exception>
#include <string>
#include "Notebook.h"


using namespace std;




int main()
{
    setlocale(LC_ALL, "Russian");

    Notebook test0;      

    // todo: Как отдавать ему "объекты" множества?
    // Notebook test1{ Checkered, 12, "ООО Забайкальский Государственный целюлозно-бумажный завод", EAC, 5 };


    Notebook test2;
    


    // Тестирование методов...
    // todo: e0: Ошибка... Как исправить?
    // test2.Set_Manufacturer("ООО Забайкальский Государственный целюлозно-бумажный завод");


    // todo: e0
    /*cout << "\n\t\tTest0:";
    test0.Get_Notebook_Information();

    cout << "\n\t\tTest2:";
    test2.Get_Notebook_Information();*/


    system("pause");
    return 0;
}