using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

using Calc = Tests.Models.Calculator.Calculator;

namespace Tests.Models.ChatBot
{
    /// <summary>
    /// 
    ///     Contain methods/properties as answers on expression/task/command/message
    /// 
    /// </summary>
    class Answer
    {

        /// <summary>
        /// 
        ///     Return random greeting
        /// 
        /// </summary>
        public string Greeting()
        {
            string[] greetings = {
            "Hello",
            "Hi",
            "Glad to see you",
            "Good day"
            };

            return greetings[new Random().Next(0, greetings.Length - 1)];
        }

        /// <summary>
        /// 
        ///     Return current time
        /// 
        /// </summary>
        public string Time()
        {
            return DateTime.Now.ToString();
        }

        /// <summary>
        /// 
        ///     Return city name
        /// 
        /// </summary>
        public string City()
        {
            using (StreamReader sr = new StreamReader(WebRequest.Create("https://ipinfo.io/city?token=d74cbf82807257").GetResponse().GetResponseStream()))
            {
                return sr.ReadToEnd().Replace("\n", null);
            }
        }

        /// <summary>
        /// 
        ///     Return weather info <br/> <br/>
        ///     <i> Examples: </i> <br/>
        ///     
        /// <code>
        /// 
        ///     -20 °C, sunny <br/>
        ///     15 °C, broken clouds
        /// 
        /// </code>
        /// 
        /// </summary>
        public string Weather()
        {
            string API_key = "580ff41b3ddf7ac053c01eec94985f50";

            string geo_url = $"http://api.openweathermap.org/geo/1.0/direct?q={City()}&limit=1&appid={API_key}";

            string tempResponce;

            using (StreamReader sr = new StreamReader(WebRequest.Create(geo_url).GetResponse().GetResponseStream()))
            {
                tempResponce = sr.ReadToEnd();
            }

            int index1 = tempResponce.IndexOf("lat") + 5;
            int index2 = tempResponce.IndexOf(",", index1);

            string lat = tempResponce.Substring(index1, index2 - index1);

            index1 = tempResponce.IndexOf("lon") + 5;
            index2 = tempResponce.IndexOf(",", index1);

            string lon = tempResponce.Substring(index1, index2 - index1);

            string weather_url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={API_key}";

            using (StreamReader sr = new StreamReader(WebRequest.Create(weather_url).GetResponse().GetResponseStream()))
            {
                tempResponce = sr.ReadToEnd();
            }

            index1 = tempResponce.IndexOf("temp") + 6;
            index2 = tempResponce.IndexOf(",", index1);

            string temperature = tempResponce.Substring(index1, index2 - index1);

            index1 = tempResponce.IndexOf("description") + 14;
            index2 = tempResponce.IndexOf("\"", index1);

            string description = tempResponce.Substring(index1, index2 - index1);

            return temperature + " °C, " + description;
        }

        /// <summary>
        /// 
        ///     Returns a string with the exchange rate of the <b> dollar, euro </b>  and <b> hryvnia </b> against the <i> <b> ruble  </b> </i> 
        ///     
        /// </summary>
        public string ExchangeRates()
        {
            XDocument xml = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp");

            string dollar = xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "840").Elements("Value").FirstOrDefault().Value,
            euro = xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "978").Elements("Value").FirstOrDefault().Value,
            hryvnia = xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x => x.Element("NumCode").Value == "980").Elements("Value").FirstOrDefault().Value;

            return $"Dollar is {dollar} rubbles\n Euro is {euro} rubbles\n Hryvnia is {hryvnia} rubbles";
            
        }

        /// <summary>
        /// 
        ///     Return IP user address
        /// 
        /// </summary>
        public string IP()
        {
            string temp;

            using (StreamReader sr = new StreamReader(WebRequest.Create("https://icanhazip.com").GetResponse().GetResponseStream()))
            {
                temp = sr.ReadToEnd();
            }

            /// Return without 2 symbols, because there is "\n" at the end
            return temp.Substring(0, temp.Length - 1);
            
        }

        /// <summary>
        /// 
        ///     Opens the default browser with a new tab with the entered query/question in Google search
        /// 
        /// </summary>
        /// <param name="searchInformation"> Inpiting search question/request </param>
        public string SearchInBrowser(string searchInformation)
        {
            System.Diagnostics.Process.Start($"https://www.google.com/search?q={searchInformation.Replace(" ", "+")}");
            return "Opened";
        }

        /// <summary>
        /// 
        ///     Return a answer inputed math expression
        /// 
        /// </summary>
        /// <param name="expression"> Inputing math expression </param>
        public string Calculate(string expression)
        {
            try
            {
                Calc.SetExpression(expression);
                Calc.GetAnswer();

                // Check if it was error!
                if (Calc.TopOperand == Double.NaN)
                {
                    return "Calculation error";
                }

                return Calc.TopOperand.ToString().Replace(",", ".");

            }
            catch
            {
                return "Calculation error";
            }
        }

        /// <summary>
        /// Return random answer to unknown request
        /// </summary>
        public string UnknownRequest()
        {
            string[] answers = {
                "Please repeat, I didn't hear you",
                "What?",
                "Oh sorry, I digress. Can you repeat please?",
                "I don't know what to answer",
                "It's not add up"
            };

            return answers[new Random().Next(0, answers.Length - 1)];
        }

    }
}
