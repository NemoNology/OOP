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

            if (string.IsNullOrEmpty(inputName.Text))
            {
                status.Content = "Username can't be empty";
                return;
            }

            mainWindow.chatbot.LoadMessages();
            mainWindow.Show();

            Close();
        }
    }
}
