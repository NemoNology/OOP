#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <iostream>
#include <QVector>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{


    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

using namespace std;




// Нажатие на кнопку "Создать случайный массив"
void MainWindow::on_pushButton_clicked()
{
    for (unsigned short i = 0; i < ui->Lines->value(); i++) {

        ui->Array_TextBox->setText("\t"); // Для удобства чтения

        for (unsigned short j = 0; j < ui->Columns->value(); j++) {

            Arr[i][j] = rand() % 200 - 100;

            ui->Array_TextBox->setText(QString::number(Arr[i][j]) + "\t");

        }

        ui->Array_TextBox->setText("\n");

    }




}


// Действия при изменении размера массива - Кол-ва строк
void MainWindow::on_Lines_valueChanged(int arg1)
{
      Arr.resize(arg1);
}

// Действия при изменении размера массива - Кол-ва столбцов
void MainWindow::on_Columns_valueChanged(int arg1)
{
    for (unsigned short i = 0; i < ui->Lines->value(); i++) {

        Arr[i].resize(arg1);

    }
}

