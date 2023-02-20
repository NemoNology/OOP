using Microsoft.Xaml.Behaviors.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Tests.Models;

namespace Tests.View_Models
{
    class ChatbotViewModel : INotifyPropertyChanged
    {

        #region Fields & Properties


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Message content from message box on UI
        /// </summary>
        private string messageContent;

        /// <summary>
        /// Buffer messages (List of messages, that changed while processing with application)
        /// </summary>
        private ObservableCollection<Message> messages = ChatbotModel.LoadMessages();


        /// <summary>
        /// Message content from message box on UI
        /// </summary>
        public string MessageContent
        {
            get => messageContent;

            set
            {
                messageContent = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MessageContent)));
            }
        }

        /// <summary>
        /// List of inputed messages
        /// </summary>
        public ObservableCollection<Message> Messages => messages;

        /// <summary>
        /// Name of current user
        /// </summary>
        public string UserName
        {
            get
            {
                return ChatbotModel.UserName;
            }

            set
            {
                ChatbotModel.ChangeUserName(value);
            }
        }

        /// <summary>
        /// Return ICommand that invoke UserSendMessage method
        /// </summary>
        public ICommand SendMessage => new ActionCommand(UserSendMessage);


        #endregion


        #region Methods


        /// <summary>
        /// Save new message from current user 
        /// </summary>
        public async void UserSendMessage()
        {
            if (string.IsNullOrEmpty(MessageContent))
            {
                return;
            }

            Messages.Add(ChatbotModel.UserSendMessage(MessageContent));

            await Task.Delay(250);

            UserGetMessage(ChatbotModel.ChatbotAnswer(MessageContent));

            MessageContent = string.Empty;
        }

        /// <summary>
        /// Save new message from another user (In our case is ChatBot)
        /// </summary>
        public void UserGetMessage(Message message)
        {
            Messages.Add(message);
        }

        /// <summary>
        /// Save local messages to user messages -> file
        /// </summary>
        public void SaveMessages()
        {
            ChatbotModel.SaveMessages(Messages);
        }

        /// <summary>
        /// Load all messages
        /// </summary>
        public void LoadMessages()
        {
            messages = ChatbotModel.LoadMessages();

            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Messages)));
        }

        #endregion
    }
}
