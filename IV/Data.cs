using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace OOP_Simple_class_C_Sharp__BAS
{

    // Класс Банковского Александра Сергеевича
    internal class Data
    {


        // Поля класса:


        // Поля класса: год, месяц, день
        private int Year, Mounth, Day;

        private bool Is_leap_year, Is_BC;



        // Методы класса:


        // Конструкторы:
        public Data()
        {

            this.Year = 0;

            this.Mounth = 1;

            this.Day = 1;



        }

        // todo: Доделай конструктор
        public Data(int year, int mounth, int day)
        {



        }


        // Сеттеры:


        // todo: Добавь переключатель Is_BC
        public void Set_Is_BC(bool flag)
        {

            if (flag)
            {

                Is_BC = true;

            }

            else
            {

                Is_BC = false;

            }

        }

        
        public void Set_year(int year)
        {

            this.Year = year;

        }


        public void Set_mounth(int mounth)
        {

            if (mounth > 0 && mounth <= 12)
            {

                this.Mounth = mounth;

            }
            else
            {

                throw new Exception("Неккорректное значение!");

            }
            

        }


        public void Set_day(int day)
        {

            int max;

            if (this.Mounth == 1 ||
                this.Mounth == 3 ||
                this.Mounth == 5 ||
                this.Mounth == 7 ||
                this.Mounth == 8 ||
                this.Mounth == 10 ||
                this.Mounth == 12)
            {

                max = 31;

            }
            else if (this.Mounth == 2)
            {

                if (this.Is_leap_year)
                {

                    max = 29;

                }

                else
                {

                    max = 28;

                }

            }
            else
            {

                max = 30;

            }
           
            if (day > 0 && day < max)
            {

                this.Day = day;

            }
            




        }


        // Геттеры:


        public int Get_year()
        {

            return this.Year;

        }


        public int Get_mounth()
        {

            return this.Mounth;

        }


        public int Get_day()
        {

            return this.Day;

        }




        // Геттеры (string):

        public string Get_string_year()
        {

            return Convert.ToString(this.Year);

        }

        // todo: Не "1", а "Январь"
        public string Get_string_mounth()
        {

            return Convert.ToString(this.Mounth);

        }



        public string Get_string_day()
        {

            return Convert.ToString(this.Day);

        }


        // todo: change the returned value
        public string Get_data()
        {

            return "Year:\t" + this.Year.ToString() + "\tMouth:\t" + this.Mounth.ToString() + "\tDay:\t" + this.Day.ToString();

        }


    }
}
