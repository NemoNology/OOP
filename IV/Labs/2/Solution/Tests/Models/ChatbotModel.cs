using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using CB = Tests.Models.ChatBot.ChatBot;

namespace Tests.Models
{
    public class ChatbotModel
    {

        private static User user = new User("Unknown");

        private static User chatbot = new User("ChatBot");

        public static string UserName => user.Name;

        /// <summary>
        /// Return new message from current user from now with inputed content
        /// </summary>
        /// <param name="content"> Inputted message content </param>
        /// <returns></returns>
        public static Message UserSendMessage(string content)
        {
            return user.WriteMessage(content);
        }

        /// <summary>
        /// Return chatbot answer on inputted request
        /// </summary>
        /// <param name="input"> Inputted request/question </param>
        /// <returns></returns>
        public static Message ChatbotAnswer(string input)
        {
            return chatbot.WriteMessage(CB.AnswerFunction(input));
        }

        /// <summary>
        /// Deserialize user (Messages, name) from binary file
        /// and put user messages to local messages
        /// </summary>
        public static ObservableCollection<Message> LoadMessages()
        {
            ObservableCollection<Message> res = new ObservableCollection<Message>();

            try
            {
                using (FileStream file = new FileStream("./Data/Users/" + user.Name + ".bin", FileMode.Open))
                {
                    user = new BinaryFormatter().Deserialize(file) as User;
                }
            }
            catch
            {
                return res;
            }
            

            for (int i = 0; i < user.MessagesCount; i++)
            {
                res.Add(user.Messages[i]);
            }

            return res;
        }

        /// <summary>
        /// Save local messages to user messages and
        /// serialize user (Messages, name) to binary file
        /// </summary>
        public static void SaveMessages(ObservableCollection<Message> messages)
        {
            user.ClearMessages();

            for (int i = 0; i < messages.Count; i++)
            {
                if (messages[i].SenderName == user.Name)
                {
                    user.SendMessage(messages[i]);
                }
                else
                {
                    user.GetMessage(messages[i]);
                }
            }

            Directory.CreateDirectory("./Data/Users");

            using (var file = new FileStream("./Data/Users/" + user.Name + ".bin", FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(file, user);
            }
        }

        /// <summary>
        /// Change current user name
        /// </summary>
        /// <param name="newName"> New current user name</param>
        public static void ChangeUserName(string newName)
        {
            user.Name = newName;
        }

    }
}
