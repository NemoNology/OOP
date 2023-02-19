using System;
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


        private const uint _commansSize = 16;
        private const uint _answersSize = 32;


        /// <summary>
        /// Array of possible questions and answers on them
        /// </summary>
        private static MyPair<string, Func<string>>[] _answers = new MyPair<string, Func<string>>[_answersSize];

        /// <summary>
        /// Array of possible commands (Request with input params) and answers on them
        /// </summary>
        private static MyPair<string, Func<string, string>>[] _commands = new MyPair<string, Func<string, string>>[_commansSize];

        /// <summary>
        ///  Length of _answers
        /// </summary>
        private static int _answersLength = 0;
        /// <summary>
        /// Length of _commands
        /// </summary>
        private static int _commandsLength = 0;


        /// <summary>
        /// Return every available answer & command as function name
        /// </summary>
        public static string Help()
        {
            string res = "List of available answers & commands (answers with input params):\n";

            for (int i = 0; i < _answersLength; i++)
            {
                res += "-) " + _answers[i].Second.Method.Name + "\n";
            }

            for (int i = 0; i < _commandsLength; i++)
            {
                res += "-) /" + _commands[i].Second.Method.Name + "\n";
            }

            return res.Substring(0, res.Length - 1);
        }


        #endregion


        #region Methods


        /// <summary>
        /// Processing inputed request/message/question/command
        /// </summary>
        /// <param name="input">  Inputting request/message/question/command  </param>
        /// <returns>
        /// Answer to input, if it's known input <br/>
        /// Random nonunderstanding - otherside
        /// Exception message - if was thrown exception
        /// </returns>
        public static string AnswerFunction(string input)
        {
            for (int i = 0; i < _answersLength; i++)
            {
                if (Regex.Match(input, _answers[i].First, RegexOptions.IgnoreCase).Success)
                {
                    return _answers[i].Second();
                }
            }

            for (int i = 0; i < _commandsLength; i++)
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

            return Answer.UnknownRequest();
        }

        /// <summary>
        /// Add new answer
        /// </summary>
        /// <param name="regex"> Regular expression that is match to answer </param>
        /// <param name="answer"> Answer to to input (if regular expression is match) </param>
        public static void AddAnswer(string regex, Func<string> answer)
        {
            _answers[_answersLength].First = regex;
            _answers[_answersLength].Second = answer;

            _answersLength++;
        }

        /// <summary>
        /// Add new command
        /// </summary>
        /// <param name="regex"> Regular expression that is match to command </param>
        /// <param name="answer"> Answer to to inputed command (if regular expression is match) </param>
        public static void AddCommand(string regex, Func<string, string> answer)
        {
            _commands[_commandsLength].First = regex;
            _commands[_commandsLength].Second = answer;

            _commandsLength++;
        }



        /// <summary>
        /// Adding to ChatBot every available answer and command
        /// </summary>
        public static void Initialization()
        {
            AddAnswer(@"^(hello|hola|hi|good (day|morning|athernoon|evening|night)|привет)+!*", Answer.Greeting);
            AddAnswer(@"^(time|(((what('s| is))|how much)( the)? time( is( it)?)?)+( now)?)+\?*", Answer.Time);
            AddAnswer(@"^(city|where am i)+\?*", Answer.City);
            AddAnswer(@"^(weather|what('s| is) weather( now)?)+\?*", Answer.Weather);
            AddAnswer(@"^(exchange rate(s)?)|((what('s| is)( the)? exchange rate(s)?( now| today)?)+\?*)", Answer.ExchangeRates);
            AddAnswer(@"^(ip)|((what('s| is)( the)? my ip)+\?*)", Answer.IP);
            AddCommand(@"^/+(search|find)( in (internet|browser))?", Answer.SearchInBrowser);
            AddCommand(@"^/+(calculate|calc)", Answer.Calculate);

            AddAnswer(@"^(/)?help", Help);
        }


        #endregion
    }
}
