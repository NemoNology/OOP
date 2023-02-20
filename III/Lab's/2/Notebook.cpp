#include <iostream>
#include <exception>
#include <string>
#include "Notebook.h"



using namespace std;



// todo: Закончи класс


// todo: Не 2 ли конструктора?..
Notebook::Notebook() {                            // Конструкторы

    Markup_Type = Markup_T::Without_Markup;
    Number_of_Sheets = 0;
    Manufacturer = "Unknown";
    Paper_Material = Paper_M::EAC;
    Size_of_Page = 5;

};


Notebook::Notebook(Markup_T M_T, unsigned short N_o_S, string Man, Paper_M P_M, unsigned short Size) {

    Markup_Type = M_T;
    Number_of_Sheets = N_o_S;
    Manufacturer = Man;
    Paper_Material = P_M;
    Size_of_Page = Size;

}



// Массив для возвращения строки с материалом бумаги
string Paper_Materials[sizeof(Notebook::Paper_M)] = { "ГОСТ", "Другая" };


string Markup_Types[sizeof(Notebook::Markup_T)] = { "В клетку", "В линию", "Без разметки", "Другая" };




//Setters:

// Set Тип разметки
void Notebook::Set_Markup_Type(Markup_T t) {

    this->Markup_Type = t;

}

// Set Кол-во листов
void Notebook::Set_Number_of_Sheets(const unsigned short &n) {

    if (n == 0) {

        throw invalid_argument("Нулевое значение...");  // Ошибочка вышла

    }
    else
    {

        this->Number_of_Sheets = n;

    }
        
}

// Set Производитель
void Notebook::Set_Manufacturer(const string &m) {

    // При вводе ничего, не меняем 
    if (m == "") {

        throw invalid_argument("Пусто...");             // Ошибочка вышла

    }
    else {

        this->Manufacturer = m;

    }
}

// Set Материал бумаги\листов
void Notebook::Set_Paper_material(Paper_M m) {

    this->Paper_Material = m;

}

// Set Размер страницы
void Notebook::Set_Size_of_Page(const unsigned short &s) {

    if (s == 0) {

        throw invalid_argument("Нулевой размер?..");    // Ошибочка вышла

    }
    else {

        this->Size_of_Page = s;

    }
}


//Getters: 
     
// Get Тип разметки
Notebook::Markup_T Notebook::Get_Markup_Type() const {

    return this->Markup_Type;

}

// Get Кол-во листов
unsigned short Notebook::Get_Number_of_Sheets() const {

    return this->Number_of_Sheets;

}

// Get Производитель
string Notebook::Get_Manufacturer() const {

    return this->Manufacturer;

}

// Get Материал бумаги\листов
Notebook::Paper_M Notebook::Get_Paper_Material() const {

    return this->Paper_Material;

}

// Get Размер страницы
unsigned short Notebook::Get_Size_of_Page() const {

    return this->Size_of_Page;

}


// Getters (string):

// Get string Тип разметки
string Notebook::Get_string_Markup_Type() const {


    return Markup_Types[this->Markup_Type];


}

// Get string Кол-во листов
string Notebook::Get_string_Number_of_Sheets() const {

    return to_string(this->Number_of_Sheets) + " листов";

}



// Get string Материал бумаги\листов
string Notebook::Get_string_Paper_Material() const {

    return Paper_Materials[this->Paper_Material];

}
                    
    

// Get Размер страницы
string Notebook::Get_string_Size_of_Page() const {

    return "A" + to_string(this->Size_of_Page);

}

// Get string инфу обо всей тетради 
string Notebook::Get_Notebook_Information() const {

    return "\n" + this->Get_string_Markup_Type() + "\t" + this->Get_string_Number_of_Sheets() +
        "\t" + this->Get_Manufacturer() + "\t" + this->Get_string_Paper_Material() + "\t" +
        this->Get_string_Size_of_Page();

}