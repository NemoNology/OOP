#include <iostream>
#include <exception>
#include <string>
#include "Notebook.h"


using namespace std;



int main()
{
    setlocale(LC_ALL, "Russian");
  


    Notebook test1(Notebook::Markup_T::Without_Markup, 96, "ООО Забайкальский Государственный целюлозно-бумажный завод", Notebook::Paper_M::Not_EAC, 5);


    Notebook test2;
    

    cout << test1.Get_Notebook_Information() << endl;


    system("pause");
    return 0;
}