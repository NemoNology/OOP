#include <iostream>
#include <exception>
#include <string>


using namespace std;


// todo: 

class Notebook {

public:                 // Создание множеств для класса Notebook


    // Тип разметки
    enum Markup_T {   

        Checkered,          // В клетку
        In_Line,            // В линию  
        Without_Markup,     // Без разметки
        Another             // Другой

    };

    enum Paper_M {          // Материал бумаги\листов

        EAC,                // ГОСТ
        Not_EAC             // Не ГОСТ

    };


private:                // Поля класса

    Markup_T Markup_Type;                   // Тип разметки
    unsigned short Number_of_Sheets;        // Кол-во листов
    string Manufacturer;                    // Производитель
    Paper_M Paper_Material;                 // Материал бумаги\листов
    unsigned short Size_of_Page;            // Размер страницы (А5, например)   

public:                 // Методы класса

    Notebook();

    Notebook(Markup_T M_T, unsigned short N_o_S, string Man, Paper_M P_M, unsigned short Size);

    //Setters:

        // Set Тип разметки
    void Set_Markup_Type(Markup_T t);

    // Set Кол-во листов
    void Set_Number_of_Sheets(const unsigned short& n);

    // Set Производитель
    void Set_Manufacturer(const string& m);

    // Set Материал бумаги\листов
    void Set_Paper_material(Paper_M m);

    // Set Размер страницы
    void Set_Size_of_Page(const unsigned short& s);


    //Getters: 

    // Get Тип разметки
    Markup_T Get_Markup_Type() const;    

    // Get Кол-во листов
    unsigned short Get_Number_of_Sheets() const;

    // Get Производитель
    string Get_Manufacturer() const;

    // Get Материал бумаги\листов
    Paper_M Get_Paper_Material() const;

    // Get Размер страницы
    unsigned short Get_Size_of_Page() const;


    // Getters (string):

    // Get string Тип разметки
    string Get_string_Markup_Type() const;

    // Get string Кол-во листов
    string Get_string_Number_of_Sheets() const;

    // Get string Материал бумаги\листов
    string Get_string_Paper_Material() const;

    // Get Размер страницы
    string Get_string_Size_of_Page() const;

    // Get string инфу обо всей тетради 
    string Get_Notebook_Information() const;

};