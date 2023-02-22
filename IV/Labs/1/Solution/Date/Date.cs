using System;
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
        private static byte[] MonthWith30days = { 4, 6, 9, 11 };
        private static string[] monthNames =
        {
            "Junuary", "February", "March", "April",
            "May", "June", "July", "August", "September",
            "October", "November", "December"
        };

        /// <summary>
        /// 
        ///     Year <br/>
        ///     Value must be non-negative
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
        ///     ћес¤ц <br/>
        ///     Value must be non-negative 
        ///     and less than a 13
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
        ///     Day <br/>
        ///     Value must be non-negative
        ///     and less than days amount in month
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
        public Date(int year = 0, int month = 1, int day = 1)
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
                else if (_month == 2)
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
                return monthNames[_month - 1];
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
            return Array.IndexOf(monthNames.Select(c => c.ToLower()).ToArray<string>(), monthname.ToLower()) + 1;
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
            return $"Year: {data.Year} \tMonth: {data.MonthName} \tDay: {data.Day}";
        }
    }
}
