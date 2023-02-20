#include <exception>
#include <string>
#include <iostream>
#include "ADT_Notebook.h"



using namespace std;


// Bankovskiy A.S.

// Constuctor without input elements
ADT_Notebook::ADT_Notebook() {

    this->Number_of_Sheets = 0;

    this->Size_of_Page = 5;

    this->Paper_Material = Paper_M::EAC;

}




// Ìàññèâ äëÿ âîçâðàùåíèÿ ñòðîêè ñ ìàòåðèàëîì áóìàãè
string Paper_Materials[sizeof(ADT_Notebook::Paper_M)] = { "ÃÎÑÒ", "Íå ÃÎÑÒ" };



//Setters:



// Set Êîë-âî ëèñòîâ
void ADT_Notebook::Set_Number_of_Sheets(const unsigned short& n) {

    if (n == 0) {

        throw invalid_argument("Íóëåâîå çíà÷åíèå...");  // Îøèáî÷êà âûøëà

    }
    else
    {

        this->Number_of_Sheets = n;

    }

}


// Set Ìàòåðèàë áóìàãè\ëèñòîâ
void ADT_Notebook::Set_Paper_material(const ADT_Notebook::Paper_M& m) {

    this->Paper_Material = m;

}

// Set Ðàçìåð ñòðàíèöû
void ADT_Notebook::Set_Size_of_Page(const unsigned short& s) {

    if (s == 0) {

        throw invalid_argument("Íóëåâîé ðàçìåð?..");    // Îøèáî÷êà âûøëà

    }
    else {

        this->Size_of_Page = s;

    }
}



//Getters: 



// Get Êîë-âî ëèñòîâ
unsigned short ADT_Notebook::Get_Number_of_Sheets() const {

    return this->Number_of_Sheets;

}


// Get Ìàòåðèàë áóìàãè\ëèñòîâ
ADT_Notebook::Paper_M ADT_Notebook::Get_Paper_Material() const {

    return this->Paper_Material;

}

// Get Ðàçìåð ñòðàíèöû
unsigned short ADT_Notebook::Get_Size_of_Page() const {

    return this->Size_of_Page;

}



// Getters (string):



// Get string Êîë-âî ëèñòîâ
string ADT_Notebook::Get_string_Number_of_Sheets() const {

    return to_string(this->Number_of_Sheets);

}



// Get string Ìàòåðèàë áóìàãè\ëèñòîâ
string ADT_Notebook::Get_string_Paper_Material() const {

    return Paper_Materials[this->Paper_Material];

}



// Get Ðàçìåð ñòðàíèöû
string ADT_Notebook::Get_string_Size_of_Page() const {

    return "A" + to_string(this->Size_of_Page);

}

// Get string èíôó îáî âñåé òåòðàäè 
string ADT_Notebook::Get_All_Information() const {

    return "Êîë-âî ëèñòîâ:\t" + ADT_Notebook::Get_string_Number_of_Sheets() +
        "\tÌàòåðèàë áóìàãè:\t" + ADT_Notebook::Get_string_Paper_Material() + "\tÐàçìåð ñòðàíèöû:\t" +
        ADT_Notebook::Get_string_Size_of_Page();

}



// Constuctor with input elements
ADT_Notebook::ADT_Notebook(unsigned short N_o_S, Paper_M P_M, unsigned short Size) {

	ADT_Notebook::Set_Number_of_Sheets(N_o_S);

	ADT_Notebook::Set_Paper_material(P_M);

	ADT_Notebook::Set_Size_of_Page(Size);

}
