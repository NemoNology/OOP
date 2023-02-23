﻿using System;
using System.Linq;

namespace Date
{
    /// <summary>
    /// 
    ///     <b>  Simple class library - Date  </b> <br/> <br/>
    /// 
    /// 
    ///     <b>  Features:  </b>
    /// 
    ///     <br/> <i>
    ///     --) Set/Get date (year, month, day) <br/>
    ///     --) Spot year leapnes <br/>
    ///     --) Spot days amount in month <br/>
    ///     --) Get month name by his number/index <br/>
    ///     --) Get month number/index by his name
    ///     </i>
    /// 
    ///     <br/> <br/>
    ///     <b>   Creator -  <i>  NemoNology (Bankovskiy Alexandr Sergeevich) </i> </b> 
    /// 
    /// </summary>
    public class Date
    {
        // Year, month and day
        private int _year, _month, _day;
        private static byte[] MonthWith30days = { 3, 4, 8, 10 };
        private static string[] monthNames =
        {
            "Junuary", "February", "March", "April",
            "May", "June", "July", "August", "September",
            "October", "November", "December"
        };

        /// <summary>
        /// Year <br/> Value must be non-negative
        /// </summary>
        public int Year
        {
            get { return _year; }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Inavalid argument: inputed value less that zero (Not non-negative)");
                }
                else
                {
                    _year = value;
                }
            }
        }

        /// <summary>
        /// Month <br/>
        /// Value must be <i> value from 0 to 11 - </i>  <c> Setting Month number <br/> </c>
        /// Value must be <i> more than 11 - </i> <c> Months Adding <br/> </c> 
        /// Value must be <i> less than 0 - </i> <c> Months Subtraction </c>
        /// </summary>
        public int Month
        {
            get { return _month; }

            set
            {
                if (value < 0 && value / 12 > _year)
                {
                    throw new Exception("Invalid argument: mounth value was less that zero and Years value is zero");
                }
                else if (value < 0)
                {
                    _year -= value / 12;
                    _month = value % 12;
                }
                else
                {
                    _year += value / 12;
                    _month = value % 12;
                }
            }
        }

        /// <summary>
        /// Day <br/>
        /// Value must be <i> value from 0 to Month Days Amount - </i>  <c> Setting Day number <br/> </c>
        /// Value must be <i> more than Month Days Amount - </i> <c> Days Adding <br/> </c> 
        /// Value must be <i> less than 0 - </i> <c> Days Subtraction </c>  
        /// </summary>
        public int Day
        {
            get { return _day; }

            set
            {
                if (value < 0 && value / 28 > _month)
                {
                    throw new Exception("Invalid argument: Day value was less that zero and Month value is zero");
                }
                else if (value < 0)
                {
                    while (value > DaysAmount - 1)
                    {
                        while (_day >= 0)
                        {
                            _day--;
                            value--;
                        }

                        Month--;
                        Day = DaysAmount - 1;
                    }

                    _day = value;
                }
                else
                {
                    value -= DaysAmount - 1 - _day;
                    _day = 0;

                    while (value > DaysAmount - 1)
                    {
                        value -= DaysAmount - 1;
                        Month++;
                    }
                    
                    _day = value;
                }
            }
        }

        /// <summary>
        /// 
        ///     Year leapness <br/> <br/> 
        ///     
        ///     Returm <c> true </c>, if year is leap; <br/>
        ///     Otherside, <c> false </c>
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
        ///      Constructor
        ///     
        /// </summary>
        public Date(int year = 0, int month = 0, int day = 0)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        ///  
        ///     Return days amount in month
        /// 
        /// </summary>
        public int DaysAmount
        {
            get
            {
                if (Array.Exists(MonthWith30days, element => element == _month))
                {
                    return 30;
                }
                else if (_month == 1)
                {
                    if (YearLeapness)
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                }
                else
                {
                    return 31;
                }

            }
        }

        /// <summary>  
        /// 
        ///     Return capitalized month name 
        /// 
        /// </summary>
        public string MonthName
        {
            get
            {
                return monthNames[_month];
            }
        }

        /// <summary>
        /// 
        ///     Return month index by his name <br/>
        ///     Index in range from 1 to 12 (0, if not found)
        ///     
        /// </summary>
        public static int GetMonthNumberByMonthName(string monthname)
        {
            return Array.IndexOf(monthNames.Select(c => c.ToLower()).ToArray<string>(), monthname.ToLower());
        }

        /// <summary>
        /// 
        ///     Return full date information as string<br/>
        ///     Example:
        /// 
        ///     <example> 
        ///         <code> 
        ///             Console.WriteLine(GetData(buffer1));
        ///             Console.WriteLine(GetData(buffer2));
        ///             
        ///             // Console out:
        ///             // Year: 2002   Month: November     Day: 12
        ///             // Year: 1991   Month: December     Day: 26
        ///         </code>
        ///     </example> 
        ///     
        /// </summary>
        public static string GetData(Date data)
        {
            return $"Year: {data._year} \tMonth: {data.MonthName} \tDay: {data._day + 1}";
        }
        

        #region Operators


        public static Date operator + (Date d1, Date d2)
        {
            return new Date(d1.Year + d2.Year, d1.Month + d2.Month, d1.Day + d2.Day);
        }

        public static Date operator - (Date d1, Date d2)
        {
            return new Date(d1.Year - d2.Year, d1.Month - d2.Month, d1.Day - d2.Day);
        }

        public static Date operator ++ (Date date)
        {
            date.Day++;
            return date;
        }

        public static Date operator -- (Date date)
        {
            date.Day--;
            return date;
        }

        public static bool operator == (Date d1, Date d2)
        {
            return (d1._year == d2._year &&
                d1._month == d2._month &&
                d1._day == d2._day);
        }

        public static bool operator != (Date d1, Date d2)
        {
            return (d1._year != d2._year ||
                d1._month != d2._month ||
                d1._day != d2._day);
        }

        public static bool operator > (Date d1, Date d2)
        {
            return 
                (d1._year > d2._year) ||
                (d1._year == d2._year && d1._month > d2._month) ||
                (d1._year == d2._year && d1._month == d2._month && d1._day > d2._day);
        }

        public static bool operator < (Date d1, Date d2)
        {
            return !(d1 > d2) && d1 != d2;
        }

        public static bool operator >= (Date d1, Date d2)
        {
            return !(d1 < d2);
        }

        public static bool operator <= (Date d1, Date d2)
        {
            return !(d1 > d2);
        }

        public static bool operator false (Date date)
        {
            return date == null ||
                (date._year == 0 && 
                date._month == 0 && 
                date._day == 0);
        }

        public static bool operator true (Date date)
        {
            return 
                date._year != 0 || 
                date._month != 0 || 
                date._day != 0;
        }


        #endregion


    }
}
