#include "Notebook.h"

// Bankovskiy A.S.



string Markup_Types[sizeof(Notebook::Markup_T)] = { "Â êëåòêó", "Â ëèíèþ", "Áåç ðàçìåòêè", "Äðóãàÿ" };



// Êîíñòðóêòîð áåç âõîäíûõ äàííûõ
Notebook::Notebook() {

    Notebook::Markup_Type = Markup_T::Without_Markup;

};








//Setters:



// Set Òèï ðàçìåòêè
void Notebook::Set_Markup_Type(Markup_T t) {

    this->Markup_Type = t;

}


// Set Ïðîèçâîäèòåëü
void Notebook::Set_Manufacturer(const string& m) {

    // Ïðè ââîäå íè÷åãî, íå ìåíÿåì 
    if (m == "") {

        throw invalid_argument("Ïóñòî...");             // Îøèáî÷êà âûøëà

    }
    else {

        this->Manufacturer = m;

    }
}



//Getters:



// Get Òèï ðàçìåòêè
Notebook::Markup_T Notebook::Get_Markup_Type() const {

    return this->Markup_Type;

}



// Get Ïðîèçâîäèòåëü
string Notebook::Get_Manufacturer() const {

    return this->Manufacturer;

}



// Getters (string):



// Get string Òèï ðàçìåòêè
string Notebook::Get_string_Markup_Type() const {


    return Markup_Types[this->Markup_Type];


}



// Get string èíôó îáî âñåé òåòðàäè 
string Notebook::Get_All_Information() const {

    return "Òèï ðàçìåòêè:\t" + Get_string_Markup_Type() + "\tÈçãîòîâèòåëü:\t" + Get_Manufacturer() + "\t" + ADT_Notebook::Get_All_Information();

}

// Êîíñòðóêòîð ñ âõîäíûìè äàííûìè
Notebook::Notebook(Markup_T M_T, string Man, unsigned short N_o_S, Paper_M P_M, unsigned short Size) {

    Set_Markup_Type(M_T);
    Set_Manufacturer(Man);

    Set_Number_of_Sheets(N_o_S);
    Set_Paper_material(P_M);
    Set_Size_of_Page(Size);

}

