using System.Windows;
using Tests.Models.ChatBot;

namespace Tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Control panel

        private void Window_Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonWindowState_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }

        }

        /// <summary>
        /// 
        ///     Window closing 
        /// 
        /// </summary>
        private void ButtonClose_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        #endregion


        private void ChatbotWindow_Closed(object sender, System.EventArgs e)
        {
            chatbot.SaveMessages();
            Close();
        }

        private void ButtonSend_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            chatbot.UserSendMessage();
            MessagesView.ScrollIntoView(MessagesView.Items[MessagesView.Items.Count - 1]);
        }
    }
}
