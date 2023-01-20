using System;

namespace OOP_Simple_class_C_Sharp__BAS
{

    /// <summary>
    /// 
    ///     <b>  Простенький класс - Дата  </b> <br/> <br/>
    /// 
    /// 
    ///     <b>  Позволяет:  </b>
    /// 
    ///     <br/> <i>
    ///     --) Назначать/Получать дату (Год, месяц, день) <br/>
    ///     --) Узнать високосность года <br/>
    ///     --) Узнать кол-во дней в месяце <br/>
    ///     --) Получить наименование месяца по его номеру <br/>
    ///     --) Получить номер месяца по его наименованию
    ///     </i>
    /// 
    ///     <br/> <br/>
    ///     <b>   Создатель -  <i>  Банковский Александр Сергеевич  </i> </b>
    /// 
    /// </summary>
    internal class Data
    {
        // Год, месяц и день
        private int _year, _month, _day;

        /// <summary>
        /// 
        ///     Год <br/>
        ///     Значение должно быть неотрицательным
        /// 
        /// </summary>
        public int Year 
        {
            get { return _year; }
            set 
            { 
                if (value < 0)
                {
                    throw new Exception("Inavalid argument: year value < 0");
                }
                else
                {
                    _year = value;
                }
            }
        }

        /// <summary>
        /// 
        ///     Месяц <br/>
        ///     Значение должно быть неотрицательным 
        ///     и меньше 13
        ///     
        /// </summary>
        public int Month
        {
            get { return _month; }

            set 
            {
                if (value < 1 || value > 12)
                {
                    throw new Exception("Invalid argument: mounth number < 1 or > 12");
                }
                else
                {
                    _month = value;
                }
            }
        }

        /// <summary>
        /// 
        ///     День <br/>
        ///     Значение должно быть неотрицательным
        ///     и не превышать количества дней в месяце
        ///     
        /// </summary>
        public int Day
        {
            get { return _day; } 

            set
            {
                if (value < 1 || value > DaysAmount)
                {
                    throw new Exception("Invalid argument: Day value < 1 or > number of days in month");
                }
                else
                {
                    _day = value;
                }
            }
        }

        /// <summary>
        /// 
        ///     Високосность года <br/> <br/> 
        ///     
        ///     Возвращает true, если год високосен <br/>
        ///     false - не високосен
        /// 
        /// </summary>
        public bool YearLeapness
        {
            get
            {
                return (_year % 4 == 0 && _year % 100 != 0) || _year % 400 == 0;
            }
        }

        /// <summary> 
        /// 
        ///     Конструктор
        ///     
        /// </summary>
        public Data(int year = 0, int month = 1, int day = 1)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        ///  
        ///     Возвращает кол-во дней в месяце
        /// 
        /// </summary>
        public int DaysAmount 
        {
            get
            {
                switch (_month)
                {
                    case 2:

                        if (YearLeapness)
                        {
                            return 29;
                        }
                        else
                        {
                            return 28;
                        }

                    case 4:
                    case 6:
                    case 9:
                    case 11:

                        return 30;

                    default: return 31;
                }
            }
        }

        /// <summary>  
        /// 
        ///     Возвращает наименование месяца на русском языке с заглавной буквы  
        /// 
        /// </summary>
        public string MonthName 
        {
            get
            {
                switch (_month)
                {
                    case 1: return "Январь";
                    case 2: return "Февраль";
                    case 3: return "Март";
                    case 4: return "Апрель";
                    case 5: return "Май";
                    case 6: return "Июнь";
                    case 7: return "Июль";
                    case 8: return "Август";
                    case 9: return "Сентябрь";
                    case 10: return "Октябрь";
                    case 11: return "Ноябрь";
                    default: return "Декабрь";
                }
            }
        }

        /// <summary>
        /// 
        ///     Вводимое наименование месяца должно быть на русском языке
        ///     
        /// </summary>
        public int GetMonthNumberByMonthName(string monthname)
        {
            switch (monthname.ToLower())
            {
                case "январь": return 1;
                case "февраль": return 2;
                case "март": return 3;
                case "апрель": return 4;
                case "май": return 5;
                case "июнь": return 6;
                case "июль": return 7;
                case "август": return 8;
                case "сентябрь": return 9;
                case "октябрь": return 10;
                case "ноябрь": return 11;
                case "декабрь": return 12;
                default: return -1;
            }
        }

        /// <summary>
        /// 
        ///     Получение полной информации в виде строки <br/>
        ///     Примеры:
        /// 
        ///     <example> 
        ///         <code> 
        ///             string buffer1 = DataClassObject1.GetData();
        ///             string buffer2 = DataClassObject2.GetData();
        ///             
        ///             Console.WriteLine(buffer1);
        ///             Console.WriteLine(buffer2);
        ///             
        ///             // Console out:
        ///             // Год: 2002    Месяц: Ноябрь   День: 12
        ///             // Год: 1991    Месяц: Декабрь  День: 26
        ///         </code>
        ///     </example> 
        ///     
        /// </summary>
        public string GetData()
        {
            
            return $"Год: {_year} \tМесяц: {MonthName} \tДень: {_day}";
        }

    }
}