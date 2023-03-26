using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

// var Author = "NemoNology - Банковский А.С.";

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

        private DataBaseModel _db = new DataBaseModel();

        /// <summary>
        /// Click on Add New Line button
        /// </summary>
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

            var age = Convert.ToInt16(inputAge.Text);

            bool sex = inputSex.SelectedIndex == 1;

            _db.InsertLine($"{id}, '{inputFName.Text}', '{inputSName.Text}', {age}, '{sex}'");

            data.ItemsSource = _db.Professors;

            RefreshID();
        }

        /// <summary>
        /// Click on Delete Selected Line button
        /// </summary>
        private void DeleteSelectedLine_Click(object sender, RoutedEventArgs e)
        {
            if (data.Items.Count == 0 || data.SelectedIndex < 0)
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

        /// <summary>
        /// Click on Update Selected Line button
        /// </summary>
        private void UpdateLine_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput || data.SelectedIndex < 0)
            {
                return;
            }

            var newID = Convert.ToInt32(inputID.Text);
            var ID = (data.Items[data.SelectedIndex] as Professor).ID;

            if (!IsIDUnique(newID, true, ID))
            {
                return;
            }

            var age = Convert.ToInt16(inputAge.Text);
            bool sex = inputSex.SelectedIndex == 1;

            _db.UpdateLine(ID, newID, inputFName.Text, inputSName.Text, age, sex);

            data.ItemsSource = _db.Professors;
            RefreshID();
        }

        /// <summary>
        /// Click on Search button
        /// </summary>
        private void Search_Click(object sender, MouseEventArgs e)
        {
            // If user don't choose any column by which user will sort the DB,
            // just warning him
            if (SearchedColumn.SelectedIndex < 0)
            {
                status.Content = "You must choose searched column";
                return;
            }

            // if user don't search anything particular, than we just sort data by user chosen column
            if (string.IsNullOrEmpty(inputSearch.Text))
            {
                // Also we check user mouse button click:
                // Left click - ascending search
                // Right click - descending search 
                _db.UpdateProfessors(SearchedColumn.Text, e.RightButton == MouseButtonState.Pressed);
                data.ItemsSource = _db.Professors;
                return;
            }

            // If user search something, that trying to find
            try
            {
                int foundRows = _db.SearchValue(SearchedColumn.Text, inputSearch.Text);

                data.ItemsSource = _db.Professors;
                status.Content = $"Found Rows Amount: {foundRows}";
            }
            catch (Exception exc)
            {
                status.Content = exc.Message;
            }
        }


        #region Features

        /// <value> Return true, if info inputs are valid <br/> False - otherwise </value>
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
                    status.Content = "Sex must be chosen";
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Check every existing ID-s
        /// </summary>
        /// <param name="id"> ID that is checked </param>
        /// <param name="IsCountSelectedID"> If true: check selected ID too </param>
        /// <param name="selectedID"> If IsCountSelectedID true, that we need to know what's ID we need to check too </param>
        /// <returns> True - if ID is unique <br/> False - otherwise </returns>
        private bool IsIDUnique(int id, bool IsCountSelectedID = false, int selectedID = 0)
        {
            foreach (var item in _db.Professors)
            {
                if (item.ID == id && !(IsCountSelectedID && item.ID == selectedID))
                {
                    status.Content = "New ID value must be unique";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Refresh inputs data, if was selected new professor
        /// </summary>
        private void DB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (data.SelectedIndex == -1)
            {
                return;
            }

            Professor chosenProfessor = data.Items[data.SelectedIndex] as Professor;

            inputID.Text = chosenProfessor.ID.ToString();
            inputFName.Text = chosenProfessor.FirstName;
            inputSName.Text = chosenProfessor.SecondName;
            inputAge.Text = chosenProfessor.Age.ToString();
            inputSex.SelectedIndex = chosenProfessor.Sex ? 1 : 0;
        }

        /// <summary>
        /// Refresh inputs ID by max ID + 1
        /// </summary>
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

        #endregion
    }
}
