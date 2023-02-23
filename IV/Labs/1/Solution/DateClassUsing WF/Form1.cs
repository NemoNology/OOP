using System;
using System.Linq;
using System.Windows.Forms;

namespace DateClassUsing_WF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Date.Date data = new Date.Date();

        /// <summary>
        /// Calculating date, when user use UI for change date
        /// </summary>
        private void Data_Changed(object sender, EventArgs e)
        {
            int year = (int)input_year.Value;
            int month = (int)input_month.Value;
            int day = (int)input_day.Value;

            try
            {
                data.Year = year;
                data.Month = month;
                data.Day = day;


                if (data.YearLeapness)
                {
                    leapness.Text = "Да";
                }
                else
                {
                    leapness.Text = "Нет";
                }

                daysAmount.Text = data.DaysAmount.ToString();
                monthName.Text = data.MonthName;

                status.Text = null;
            }
            catch (Exception exp)
            {
                status.Text = exp.Message;

                leapness.Text = daysAmount.Text = monthName.Text = null;
            }
        }

        /// <summary>
        /// Geneate new date array and add dates to TextBox on UI
        /// </summary>
        private void b_generate_Click(object sender, EventArgs e)
        {
            int size = 10;

            Date.Date[] dates = new Date.Date[size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                dates[i] = new Date.Date(rnd.Next(0, 5000), rnd.Next(1, 12));
                dates[i].Day = rnd.Next(1, dates[i].DaysAmount);
            }

            arrayOfData.Lines = null;

            foreach (Date.Date data in dates)
            {
                arrayOfData.Lines = arrayOfData.Lines.Append(data.DateInfo).ToArray<string>();
            }
        }
    }
}
