using System;
using System.Linq;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RefreshID();
        }

        DataBaseModel _db = new DataBaseModel();

        private void AddNewLine_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput)
            {
                return;
            }

            var id = Convert.ToInt32(inputID.Text);

            if (!IsIDUnique(id))
            {
                status.Content = "ID must be unique";
                return;
            }

            var age = Convert.ToInt32(inputAge.Text);

            bool sex = inputSex.SelectedIndex == 1;

            _db.InsertLine($"{id}, '{inputFName.Text}', '{inputSName.Text}', {age}, '{sex}'");

            data.ItemsSource = _db.Professors;

            RefreshID();
        }

        private void DB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (data.SelectedIndex == -1)
            {
                return;
            }

            Professor chosenProfessor = data.Items[data.SelectedIndex] as Professor;

            inputID.Text = chosenProfessor.ID.ToString();
            inputFName.Text = chosenProfessor.FirstName;
            inputSName.Text = chosenProfessor.SecondtName;
            inputAge.Text = chosenProfessor.Age.ToString();
        }

        private void DeleteSelectedLine_Click(object sender, RoutedEventArgs e)
        {
            if (data.Items.Count == 0 || data.SelectedIndex == -1)
            {
                return;
            }

            var currentSelectedIndex = data.SelectedIndex;

            Professor chosenProfessor = data.Items[currentSelectedIndex] as Professor;

            _db.DeleteLine(chosenProfessor.ID);

            data.ItemsSource = _db.Professors;

            data.SelectedIndex = currentSelectedIndex - 1;
            RefreshID();
        }

        private bool IsValidInput
        {
            get
            {
                if (!int.TryParse(inputID.Text, out _))
                {
                    status.Content = "Invalid ID value";
                    return false;
                }

                if (string.IsNullOrEmpty(inputFName.Text))
                {
                    status.Content = "Invalid First name";
                    return false;
                }

                if (string.IsNullOrEmpty(inputSName.Text))
                {
                    status.Content = "Invalid Second name";
                    return false;
                }

                if (!short.TryParse(inputAge.Text, out _))
                {
                    status.Content = "Invalid Age value";
                }

                if (inputSex.SelectedIndex != 0 && inputSex.SelectedIndex != 1)
                {
                    status.Content = "Sex must be choosen";
                    return false;
                }

                return true;
            }
        }

        private bool IsIDUnique(int id)
        {
            foreach (var item in _db.Professors)
            {
                if (item.ID == id)
                    return false;
            }

            return true;
        }

        private void RefreshID()
        {
            if (_db.Professors.Count != 0)
            {
                inputID.Text = (_db.Professors.Max(x => x.ID) + 1).ToString();
            }
            else
            {
                inputID.Text = "0";
            }
        }
    }
}
