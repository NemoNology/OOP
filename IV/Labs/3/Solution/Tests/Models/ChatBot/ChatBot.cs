using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tests.Models.Features;

namespace Tests.Models.ChatBot
{
    
    /// <summary>
    /// Class Chat-Bot <br/> <br/>
    /// Return answer on your question or command
    /// </summary>
    public class ChatBot
    {

        #region Fields & Properties

        private Answer answers = new Answer();

        /// <summary>
        /// Array of possible questions and answers on them
        /// </summary>
        private List<MyPair<string, Func<string>>> _answers = new List<MyPair<string, Func<string>>>();

        /// <summary>
        /// Array of possible commands (Request with input params) and answers on them
        /// </summary>
        private List<MyPair<string, Func<string, string>>> _commands = new List<MyPair<string, Func<string, string>>>();


        /// <summary>
        /// Return every available answer & command as function name
        /// </summary>
        public string Help()
        {
            string res = "List of available answers & commands (answers with input params):\n";

            for (int i = 0; i < _answers.Count; i++)
            {
                res += "-) " + _answers[i].Second.Method.Name + "\n";
            }

            for (int i = 0; i < _commands.Count; i++)
            {
                res += "-) /" + _commands[i].Second.Method.Name + "\n";
            }

            return res.Substring(0, res.Length - 1);
        }


        #endregion


        #region Methods


        /// <summary>
        /// Initialize a new ChatBot object with Initialization method
        /// </summary>
        public ChatBot()
        {
            this.Initialization();
        }

        /// <summary>
        /// Processing inputed request/message/question/command
        /// </summary>
        /// <param name="input">  Inputting request/message/question/command  </param>
        /// <returns>
        /// Answer to input, if it's known input <br/>
        /// Random nonunderstanding - otherside
        /// Exception message - if was thrown exception
        /// </returns>
        public string AnswerFunction(string input)
        {
            for (int i = 0; i < _answers.Count; i++)
            {
                if (Regex.Match(input, _answers[i].First, RegexOptions.IgnoreCase).Success)
                {
                    return _answers[i].Second();
                }
            }

            for (int i = 0; i < _commands.Count; i++)
            {
                if (Regex.Match(input, _commands[i].First, RegexOptions.IgnoreCase).Success)
                {
                    try
                    {
                        return _commands[i].Second(Regex.Replace(input, _commands[i].First, string.Empty, RegexOptions.IgnoreCase));
                    }
                    catch (Exception exc)
                    {
                        return "Error: was thrown exception:\n" + exc.Message;
                    }
                }
            }

            return answers.UnknownRequest();
        }

        /// <summary>
        /// Add new answer
        /// </summary>
        /// <param name="regex"> Regular expression that is match to answer </param>
        /// <param name="answer"> Answer to to input (if regular expression is match) </param>
        public void AddAnswer(string regex, Func<string> answer)
        {
            _answers.Add(new MyPair<string, Func<string>>(regex, answer));
        }

        /// <summary>
        /// Add new command
        /// </summary>
        /// <param name="regex"> Regular expression that is match to command </param>
        /// <param name="answer"> Answer to to inputed command (if regular expression is match) </param>
        public void AddCommand(string regex, Func<string, string> command)
        {
            _commands.Add(new MyPair<string, Func<string, string>>(regex, command));
        }


        /// <summary>
        /// Adding to ChatBot every available answer and command
        /// </summary>
        public void Initialization()
        {
            AddAnswer(@"^(hello|hola|hi|good (day|morning|athernoon|evening|night)|привет)+!*", answers.Greeting);
            AddAnswer(@"^(time|(((what('s| is))|how much)( the)? time( is( it)?)?)+( now)?)+\?*", answers.Time);
            AddAnswer(@"^(city|where am i)+\?*", answers.City);
            AddAnswer(@"^(weather|what('s| is) weather( now)?)+\?*", answers.Weather);
            AddAnswer(@"^(exchange rate(s)?)|((what('s| is)( the)? exchange rate(s)?( now| today)?)+\?*)", answers.ExchangeRates);
            AddAnswer(@"^(ip)|((what('s| is)( the)? my ip)+\?*)", answers.IP);
            AddCommand(@"^/+(search|find)( in (internet|browser))?", answers.SearchInBrowser);
            AddCommand(@"^/+(calculate|calc)", answers.Calculate);

            AddAnswer(@"^(/)?help", Help);
        }


        #endregion
    }
}
