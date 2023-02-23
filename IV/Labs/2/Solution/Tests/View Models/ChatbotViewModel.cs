using Microsoft.Xaml.Behaviors.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Tests.Models;

namespace Tests.View_Models
{
    class ChatbotViewModel : INotifyPropertyChanged
    {

        #region Fields & Properties

        private ChatbotModel chatbotModel = new ChatbotModel();

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Message content from message box on UI
        /// </summary>
        private string messageContent;

        /// <summary>
        /// Buffer messages (List of messages, that changed while processing with application)
        /// </summary>
        private ObservableCollection<Message> messages = new ObservableCollection<Message>();


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
                return chatbotModel.UserName;
            }

            set
            {
                chatbotModel.ChangeUserName(value);
            }
        }

        /// <summary>
        /// Return ICommand that invoke UserSendMessage method
        /// </summary>
        public ICommand SendMessage => new ActionCommand(UserSendMessage);


        #endregion


        #region Methods

        /// <summary>
        /// Initialize a new ChatbotViewModel object with LoadMessages method
        /// </summary>
        public ChatbotViewModel()
        {
            messages = chatbotModel.LoadMessages(); 
        }

        /// <summary>
        /// Save new message from current user 
        /// </summary>
        public async void UserSendMessage()
        {
            if (string.IsNullOrEmpty(MessageContent))
            {
                return;
            }

            Messages.Add(chatbotModel.UserSendMessage(MessageContent));

            // "await" - Async wait while Method will be completed
            // In our case: async wait while process 250 ml sec
            await Task.Delay(450);

            UserGetMessage(chatbotModel.ChatbotAnswer(MessageContent));

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
            chatbotModel.SaveMessages(Messages);
        }

        /// <summary>
        /// Load all messages
        /// </summary>
        public void LoadMessages()
        {
            messages = chatbotModel.LoadMessages();

            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Messages)));
        }

        #endregion
    }
}
