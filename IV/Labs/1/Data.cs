using System;

namespace OOP_Simple_class_C_Sharp__BAS
{

    /// <summary>
    /// 
    ///     <b>  ����������� ����� - ����  </b> <br/> <br/>
    /// 
    /// 
    ///     <b>  ���������:  </b>
    /// 
    ///     <br/> <i>
    ///     --) ���������/�������� ���� (���, �����, ����) <br/>
    ///     --) ������ ������������ ���� <br/>
    ///     --) ������ ���-�� ���� � ������ <br/>
    ///     --) �������� ������������ ������ �� ��� ������ <br/>
    ///     --) �������� ����� ������ �� ��� ������������
    ///     </i>
    /// 
    ///     <br/> <br/>
    ///     <b>   ��������� -  <i>  ���������� ��������� ���������  </i> </b>
    /// 
    /// </summary>
    internal class Data
    {
        // ���, ����� � ����
        private int _year, _month, _day;

        /// <summary>
        /// 
        ///     ��� <br/>
        ///     �������� ������ ���� ���������������
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
        ///     ����� <br/>
        ///     �������� ������ ���� ��������������� 
        ///     � ������ 13
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
        ///     ���� <br/>
        ///     �������� ������ ���� ���������������
        ///     � �� ��������� ���������� ���� � ������
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
        ///     ������������ ���� <br/> <br/> 
        ///     
        ///     ���������� true, ���� ��� ��������� <br/>
        ///     false - �� ���������
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
        ///     �����������
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
        ///     ���������� ���-�� ���� � ������
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
        ///     ���������� ������������ ������ �� ������� ����� � ��������� �����  
        /// 
        /// </summary>
        public string MonthName 
        {
            get
            {
                switch (_month)
                {
                    case 1: return "������";
                    case 2: return "�������";
                    case 3: return "����";
                    case 4: return "������";
                    case 5: return "���";
                    case 6: return "����";
                    case 7: return "����";
                    case 8: return "������";
                    case 9: return "��������";
                    case 10: return "�������";
                    case 11: return "������";
                    default: return "�������";
                }
            }
        }

        /// <summary>
        /// 
        ///     �������� ������������ ������ ������ ���� �� ������� �����
        ///     
        /// </summary>
        public int GetMonthNumberByMonthName(string monthname)
        {
            switch (monthname.ToLower())
            {
                case "������": return 1;
                case "�������": return 2;
                case "����": return 3;
                case "������": return 4;
                case "���": return 5;
                case "����": return 6;
                case "����": return 7;
                case "������": return 8;
                case "��������": return 9;
                case "�������": return 10;
                case "������": return 11;
                case "�������": return 12;
                default: return -1;
            }
        }

        /// <summary>
        /// 
        ///     ��������� ������ ���������� � ���� ������ <br/>
        ///     �������:
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
        ///             // ���: 2002    �����: ������   ����: 12
        ///             // ���: 1991    �����: �������  ����: 26
        ///         </code>
        ///     </example> 
        ///     
        /// </summary>
        public string GetData()
        {
            
            return $"���: {_year} \t�����: {MonthName} \t����: {_day}";
        }

    }
}