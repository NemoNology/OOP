using System;

namespace Tests.Models
{
    [Serializable]
    public class Message 
    {
        /// <summary>
        /// Message sender name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Message sent time
        /// </summary>
        public DateTime DispatchTime { get; set; }

        /// <summary>
        /// Message content - text
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initialize a message
        /// </summary>
        /// <param name="senderName"> Message sender name </param>
        /// <param name="dispatchTime"> Message sent time </param>
        /// <param name="content"> Massage content - text </param>
        public Message(string senderName, DateTime dispatchTime, string content)
        {
            SenderName = senderName;
            DispatchTime = dispatchTime;
            Content = content;
        }

        /// <summary>
        /// Initialize a message
        /// </summary>
        /// <param name="message"> From this inputed message will be taken all params for new message </param>
        public Message(Message message)
        {
            SenderName = message.SenderName;
            DispatchTime = message.DispatchTime;
            Content = message.Content;
        }
    }
}
