#pragma once
#include "ADT_Notebook.h"


// Bankovskiy A.S.


class Notebook : public ADT_Notebook
{

public:                 // Ñîçäàíèå ìíîæåñòâ äëÿ êëàññà Notebook


// Òèï ðàçìåòêè
    enum Markup_T {

        Checkered,              // Â êëåòêó
        In_Line,                // Â ëèíèþ  
        Without_Markup,         // Áåç ðàçìåòêè
        Another                 // Äðóãîé

    };

private:                // Ïîëÿ êëàññà

    Markup_T Markup_Type;                   // Òèï ðàçìåòêè

    string Manufacturer;                    // Ïðîèçâîäèòåëü

public:                 // Ìåòîäû êëàññà



    // Êîíñòðóêòîð áåç âõîäíûõ äàííûõ
    Notebook();



    //Setters:



    // Set Òèï ðàçìåòêè
    void Set_Markup_Type(Markup_T t);



    // Set Ïðîèçâîäèòåëü
    void Set_Manufacturer(const string& m);

    


    //Getters: 



    // Get Òèï ðàçìåòêè
    Markup_T Get_Markup_Type() const;



    // Get Ïðîèçâîäèòåëü
    string Get_Manufacturer() const;



    // Getters (string):



    // Get string Òèï ðàçìåòêè
    string Get_string_Markup_Type() const;


    // Get string èíôó îáî âñåé òåòðàäè 
    string Get_All_Information() const;


    // Êîíñòðóêòîð ñ âõîäíûìè äàííûìè
    Notebook(Markup_T M_T, string Man, unsigned short N_o_S, Paper_M P_M, unsigned short Size);

};

