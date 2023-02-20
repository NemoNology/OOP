#pragma once
#include <exception>
#include <iostream>
#include <string>



using namespace std;



class ADT_Notebook {


public:                 // Создание множеств для класса ADT_Notebook


    enum Paper_M {          // Материал бумаги\листов

        EAC,                // ГОСТ
        Not_EAC             // Не ГОСТ

    };


private:                // Поля класса


    unsigned short Number_of_Sheets;        // Кол-во листов
    Paper_M Paper_Material;                 // Материал бумаги\листов
    unsigned short Size_of_Page;            // Размер страницы (А5, например)   


public:                 // Методы класса

    // Конструктор без принимаемых значений
    ADT_Notebook();



    //Setters:



    // Set Кол-во листов
    void Set_Number_of_Sheets(const unsigned short& n);


    // Set Материал бумаги\листов
    void Set_Paper_material(const Paper_M& m);


    // Set Размер страницы
    void Set_Size_of_Page(const unsigned short& s);



    //Getters: 



    // Get Кол-во листов
    unsigned short Get_Number_of_Sheets() const;


    // Get Материал бумаги\листов
    Paper_M Get_Paper_Material() const;


    // Get Размер страницы
    unsigned short Get_Size_of_Page() const;



    // Getters (string):



    // Get string Кол-во листов
    string Get_string_Number_of_Sheets() const;

    // Get string Материал бумаги\листов
    string Get_string_Paper_Material() const;

    // Get Размер страницы
    string Get_string_Size_of_Page() const;

    // Get string инфу обо всей тетради 
    string Get_All_Information() const;



    // Конструктор с принимаемыми значениями
    ADT_Notebook(unsigned short N_o_S, Paper_M P_M, unsigned short Size);

};