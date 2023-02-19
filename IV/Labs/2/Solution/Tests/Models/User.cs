using System;
using System.Windows.Media;

namespace Tests.Models
{
    [Serializable]
    public class User
    {

        #region Fields & Properties

        public static readonly byte messagesSize = 64;

        // User name
        private string name;
        
        // Store massages history
        private Message[] messages = new Message[messagesSize];

        // Massages index - count not null messages in field "massages" from array start (from 0)
        private byte messagesCount = 0;


        /// <summary>
        /// User name
        /// </summary>
        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(Name)} can't be null or empty");
                }

                for (int i = 0; i < messagesCount; i++)
                {
                    if (messages[i].SenderName == name)
                    {
                        messages[i].SenderName = value;
                    }
                }

                name = value;
            }
        }

        /// <summary>
        /// All sent and came messages
        /// </summary>
        public Message[] Messages => messages;

        /// <summary>
        /// Return not null messages amount
        /// </summary>
        public byte MessagesCount => messagesCount;

        #endregion

        #region Methods & (De)Constructor

        /// <summary>
        /// Initialize a user
        /// </summary>
        /// <param name="name"> User name </param>
        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Send message - save sent message to messages (Array)
        /// </summary>
        /// <param name="message"> Message that need to be sent </param>
        public void SendMessage(Message message)
        {
            messages[messagesCount] = new Message(message);
            messagesCount++;
        }

        /// <summary>
        /// Get message - save incomming message to messages (Array)
        /// </summary>
        /// <param name="message"> Message that came </param>
        public void GetMessage(Message message)
        {
            messages[messagesCount] = new Message(message);
            messagesCount++;
        }

        /// <summary>
        /// Create/Write a new message
        /// </summary>
        /// <param name="content"> Inputted content </param>
        /// <returns> New message from this user from now with inputted content </returns>
        public Message WriteMessage(string content)
        {
            return new Message(Name, DateTime.Now, content);
        }

        /// <summary>
        /// Delete\Clear all messages
        /// </summary>
        public void ClearMessages()
        {
            for (int i = 0; i < messagesCount; i++)
            {
                messages[i] = null;
            }

            messagesCount = 0;
        }

        #endregion

    }
}
