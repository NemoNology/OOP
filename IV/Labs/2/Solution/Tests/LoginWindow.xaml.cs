using System;
using System.Windows;

namespace Tests
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            try
            {
                mainWindow.chatbot.UserName = inputName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            mainWindow.chatbot.LoadMessages();
            mainWindow.Show();

            Close();
        }
    }
}
