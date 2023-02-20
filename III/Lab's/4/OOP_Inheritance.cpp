#include <iostream>
#include "ADT_Notebook.h"
#include "Notebook.h"
#include "Book.h"
#include "Newspaper.h"


using namespace std;


// Bankovskiy A.S.


int main()
{
	setlocale(LC_ALL, "Russian");

	ADT_Notebook test1(12, ADT_Notebook::Paper_M::EAC, 5);

	cout  << test1.Get_All_Information() << "\n\n";



	Notebook test2(Notebook::Markup_T::In_Line, "BELL", 21, ADT_Notebook::Paper_M::EAC, 5);

	cout << test2.Get_All_Information() << "\n\n";


	Book t3("П.П.", "22.12.2021", "2-ой сборник стихотворений", 21, ADT_Notebook::Paper_M::Not_EAC, 5);

	cout << t3.Get_All_Information() << "\n\n";


	Newspaper t4("BELL", "12.12.2011", 32, ADT_Notebook::Paper_M::EAC, 4);

	cout << t4.Get_All_Information() << "\n\n";


	system("pause");
	return 0;

}
