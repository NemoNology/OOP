using System;
using System.Linq;
using System.Windows.Forms;

namespace OOP__IV__Lab_7_WF
{
    public partial class Form1 : Form
    {
		/// <summary>
        /// Main calculator
        /// </summary>
		Calculator calculator = new Calculator();
		
        /// <summary>
        /// Previuos expression
        /// </summary>
        private string prevExp = string.Empty;
        /// <summary>
        /// Current math expression
        /// </summary>
        private string expression = string.Empty;
        /// <summary>
        /// Array that keeps all calculated expressions
        /// </summary>
        private string[] expressionHistory = new string[Byte.MaxValue];

        /// <summary>
        /// Index of chosen (Current) expression by hotkeys <br/>
        /// <i>  Kostyl...  </i>
        /// </summary>
        private byte index = 0;

        /// <summary>
        /// Value that keep expressions amount in expressionHistory
        /// </summary>
        /// <value>  expressionHstory - array that keeps all calculated expressions  </value>
        private byte expressionCount = 0;


        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Any digit button click (0..9)
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void Digit_Click(object sender, EventArgs e)
        {
            if (IsArithmeticFunction())
            {
                return;
            }
            else if (IsNumber())
            {
                expression += " ";
            }

            Button clickedButton = (Button)sender;

            expression += clickedButton.Text;

            Expression_Changed();
            
        }

        /// <summary>
        /// Any triginometric function or one operand function button click <br/>
        /// <i>  Cos, sin, tan, exp, ln </i>
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void TriginometricFunction_Click(object sender, EventArgs e)
        {
            if (!IsNumber() && expression.Length != 0)
            {
                return;
            }

            Button clickedButton = (Button)sender;
            expression += " " + (clickedButton.Text) + " (";

            Expression_Changed();
        }

        /// <summary>
        /// Any arithmetic function button click <br/>
        /// <i>  Add, sub, div, mul, ^ </i>
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void ArithmeticFunction_Click(object sender, EventArgs e)
        {
            if (expression.EndsWith("."))
            {
                expression = expression.Remove(expression.Length - 1);
            }

            Button clickedButton = (Button)sender;

            clickedButton.Text = clickedButton.Text.Replace("÷", "/").Replace("×", "*");

            if (clickedButton.Text == "-")
            {
                if (expression.Trim(' ').EndsWith("+") || expression.Trim(' ').EndsWith("m"))
                {                      
                    ChangeSign();      
                }     
                else if (IsNumber())
                {
                    expression += " -1 *";
                }
                else
                {
                    expression += " m";
                }
            }
            else if (expression.Length == 0)
            {
                return;
            }
            else if (clickedButton.Text == expression.Last().ToString())
            {
                return;
            }
            else if (clickedButton.Text == "+")
            {
                if (expression.Trim(' ').EndsWith("m"))
                {
                    ChangeSign();
                }
                else
                {
                    expression += " +";
                }
            }
            else
            {
                expression += " " + clickedButton.Text;
            }

            Expression_Changed();
        }

        /// <summary>
        /// Open/Closed hook button click
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void Hook_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            expression += " " + clickedButton.Text;

            Expression_Changed();
        }

        /// <summary>
        /// Dot button click
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void Dot_Click(object sender, EventArgs e)
        {
            if (expression.Length == 0)
            {
                return;
            }

            string number = GetNumberAtTheEnd();

            if (number.IndexOf(",") != -1 || number.Length == 0)
            {
                return;
            }

            expression += ",";

            Expression_Changed();
        }

        /// <summary>
        /// "C" button click <br/>
        /// Clear last digit or operation
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void Clear_Click(object sender, EventArgs e)
        {
            if (expression.Length == 0)
            {
                return;
            }
            else if (expression.Trim(' ').LastIndexOf(" ") != -1)
            {
                string number = GetNumberAtTheEnd();

                if (expression.IndexOf(number) > expression.IndexOf(" "))
                {
                    expression = expression.Remove(expression.Length - 1);
					number = number.Remove(number.Length - 1);

                    if (number.Length == 0)
                    {
                        expression = expression.Remove(expression.Length - 1);
                    }
                }
                else
                {
                    expression = expression.Remove(expression.LastIndexOf(" "));
                }
            }
            else
            {
                expression = expression.Remove(expression.Length - 1);
            }

            previousExpression.Text = string.Empty;

            Expression_Changed();
        }

        /// <summary>
        /// "CE" button click <br/>
        ///  Clear all
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void ClearEverything_Click(object sender, EventArgs e)
        {
            expression = previousExpression.Text = string.Empty;

            Expression_Changed();
        }

        /// <summary>
        /// Change operation sign for expression <br/> <br/>
        /// <example>  If last operation is ADD, than it will be SUB  </example> <br/>
        /// <example>  If last operation is SUB, than it will be ADD  </example>
        /// </summary>
        public void ChangeSign()
        {
            expression = expression.Trim(' ');
            char sign = expression.Last();
            expression = expression.Remove(expression.Length - 1);

            if (sign == 'm' && expression.Length == 0)
            {
                expression = string.Empty;
            }
            else if (sign == 'm')
            {
                expression += "+";
            }
            else 
            {
                expression += "m";
            }

            Expression_Changed();
        }

        /// <summary>
        /// "=" button click <br/>
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void GetAnswer_Click(object sender, EventArgs e)
        {
            if (expression.Count(x => x == '(') != expression.Count(x => x == ')'))
            {
                previousExpression.Text = "Не все скобки закрыты!";
                return;
            }
            else if (expression.Length == 0)
            {
                expression += "0";
            }

            try
            {
                calculator.SetExpression(expression);
                input.Text = calculator.GetAnswer().ToString().Replace(",", ".");

                prevExp = expression;
                previousExpression.Text = ConvertToNormalViev(expression);
                History_Append(expression);

                expression = input.Text;
            }
            catch
            {
                previousExpression.Text = "Error!";
            }

            // Check if it was error!
            if (calculator.TopOperand == Double.NaN)
            {
                status.Text = "Maybe imaginary unit or undefined function";
                Timer_5s.Start();
                input.Text = "Error!";
            }
        }

        /// <summary>
        /// History at the statusbar click <br/>
        /// Reload expression history 
        /// </summary>
        /// <param name="sender"> Clicked button </param>
        private void History_Click(object sender, EventArgs e)
        {
            history.Items.Clear();

            for (int i = expressionCount - 1; i >= 0; i--)
            {
                history.Items.Add(ConvertToNormalViev(expressionHistory[i]));
            }
        }

        /// <summary>
        /// Show var "expression" in "input" textBox
        /// </summary>
        public void Expression_Changed()
        {
            input.Text = ConvertToNormalViev(expression);
        }

        /// <summary>
        /// Change expression replaceing current expression by expression chosen from history
        /// </summary>
        /// <param name="index"> Expression index, that chosen from expression history </param>
        public void ExpressionFromHistory_Selected(int index)
        {
            if (expressionCount == 0)
            {
                return;
            }

            previousExpression.Text = prevExp = string.Empty;

            expression = expressionHistory[expressionCount - 1 - index].ToString();

            Expression_Changed();
        }

        /// <summary>
        /// Invoke when chose new expression from epxression history by clicking
        /// </summary>
        private void SelectedIndex_Changed(object sender, EventArgs e)
        {
            ExpressionFromHistory_Selected(history.SelectedIndex);
            index = (byte)history.SelectedIndex;
        }

        /// <summary>
        ///  Check if now inputting a numer
        /// </summary>
        /// <returns> 
        /// <c> True </c> - now inputting a number <br/>
        /// <c> False </c> - otherside
        /// </returns>
        public bool IsNumber()
        {
            return 
                expression.EndsWith("+") || expression.EndsWith("m") || 
                expression.EndsWith("/") || expression.EndsWith("*") ||
                expression.EndsWith("(") || expression.EndsWith(" ") ||
                expression.EndsWith("^") || expression.Length == 0;
        }

        /// <summary>
        ///  Check if now inputting a arithmetical function
        /// </summary>
        /// <returns> 
        /// <c> True </c> - now inputting a arithmetical function <br/>
        /// <c> False </c> - otherside
        /// </returns>
        public bool IsArithmeticFunction()
        {
            return 
                expression.EndsWith(")") || expression.EndsWith("n") ||
                expression.EndsWith("s") || expression.EndsWith("p");
        }

        /// <summary>
        /// Invoke when user hover his cursour on previuos expresion
        /// </summary>
        /// <value>  Previuos expresion - expression, that is above inputting expression  </value>
        private void PreviousExpression_MouseHover(object sender, EventArgs e)
        {
            previousExpression.ForeColor = input.ForeColor;
        }

        /// <summary>
        /// Invoke when user click on previuos expresion
        /// </summary>
        /// <value>  Previuos expresion - expression, that is above inputting expression  </value>
        private void PreviousExpression_Click(object sender, EventArgs e)
        {
            if (previousExpression.Text == "Ошибка!" || previousExpression.Text.Length == 0)
            {
                return;
            }

            expression = prevExp;

            previousExpression.Text = string.Empty;

            Expression_Changed();
        }

        /// <summary>
        /// Invoke when user leave his cursour from previuos expresion
        /// </summary>
        /// <value>  Previuos expresion - expression, that is above inputting expression  </value>
        private void PreviousExpression_MouseLeave(object sender, EventArgs e)
        {
            previousExpression.ForeColor = System.Drawing.Color.Silver;
        }

        /// <summary>
        /// Return number at the expression end 
        /// </summary>
        /// <returns> 
        /// <b> Number </b> - if there is number at the end of inputed expression <br/>
        /// <b> Empty string </b>  - otherside
        /// </returns>
        public string GetNumberAtTheEnd()
        {
            string digits = "-0123456789.";

            int i = expression.Length - 1;

            string number = string.Empty;

            while (digits.Contains(expression[i]))
            {
                number += expression[i];
                i--;
            }

            char[] numberChars = number.ToCharArray();
            Array.Reverse(numberChars);

            return new string(numberChars);
        }

        /// <summary>
        ///  Adding new inputed expression to expression history
        /// </summary>
        /// <param name="item">  Adding expression  </param>
        public void History_Append(string item)
        {
            if (expressionHistory.Contains(item))
            {
                for (int i = Array.IndexOf(expressionHistory, item); i < expressionCount; i++)
                {
                    expressionHistory[i] = expressionHistory[i + 1];
                }
               
                expressionHistory[expressionCount - 1] = item;
            }
            else
            {
                expressionHistory[expressionCount] = item;
                expressionCount++;
            }
        }

        /// <summary>
        /// Convert inputed expression to 'normal' viev and return converted expression
        /// </summary>
        /// <value>  <i> Normal viev: </i> <br/>
        /// + Deleted " "; <br/>
        /// + Replace " , " to " . "; <br/>
        /// + Replace " -1 * " and " m " to " - "  <br/>
        /// </value>
        /// <param name="str">  Inputed expression  </param>
        /// <returns>  Converted expression  </returns>
        public string ConvertToNormalViev(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "0";
            }
            else
            {
                return str.Replace("-1 *", "-").Replace("m", "-").Replace(" ", "").Replace(",", ".");
            }
        }

        /// <summary>
        ///  Hot keys
        /// </summary>
        private void Key_Down(object sender, KeyEventArgs e)
        {
            // Open hook
            if (e.Shift && e.KeyCode == Keys.D0)
            {
                Button clickenButton = new Button();
                clickenButton.Text = ")";

                Hook_Click(clickenButton, e);
            }
            // Closed hook
            else if (e.Shift && e.KeyCode == Keys.D9)
            {
                Button clickenButton = new Button();
                clickenButton.Text = "(";

                Hook_Click(clickenButton, e);
            }
            // Click on previous expresion - Ctrl + Backspace
            else if (e.Control && e.KeyCode == Keys.Back)
            {
                PreviousExpression_Click(sender, e);
            }
            // Click on ^ - Shift + 6
            else if (e.Shift && e.KeyCode == Keys.D6)
            {
                Button clickenButton = new Button();
                clickenButton.Text = "^";

                ArithmeticFunction_Click(clickenButton, e);
            }
            // Click on any digit key - 0..9 or numpad 0..9
            else if (GetDigitByKey(e.KeyCode) != string.Empty)
            {
                Button clickenButton = new Button();
                clickenButton.Text = GetDigitByKey(e.KeyCode);

                Digit_Click(clickenButton, e);
            }
            // Click on any ariphmetical function button - +, -, *, /
            else if (GetArithmeticFunctionByKey(e.KeyCode) != string.Empty)
            {
                Button clickenButton = new Button();
                clickenButton.Text = GetArithmeticFunctionByKey(e.KeyCode);

                ArithmeticFunction_Click(clickenButton, e);
            }
            // Click on any triginometric function button - S, C, T, L, E
            else if (GetTriginometricFunctionByKey(e.KeyCode) != string.Empty)
            {
                Button clickenButton = new Button();
                clickenButton.Text = GetTriginometricFunctionByKey(e.KeyCode);

                TriginometricFunction_Click(clickenButton, e);
            }
            // Click on clear everything button - Shift + Backspace
            else if (e.Shift && e.KeyCode == Keys.Back)
            {
                ClearEverything_Click(sender, e);
            }
            // Click on clear button - Backspace
            else if (e.KeyCode == Keys.Back)
            {
                Clear_Click(sender, e);
            }
            // Click on get answer (" = ") button - Shift + Enter or R or Shift + Return
            else if ((e.Shift && e.KeyCode == Keys.Enter) || 
                (e.Shift && e.KeyCode == Keys.Return) ||
                e.KeyCode == Keys.R)
            {
                GetAnswer_Click(sender, e);
            }
            // Click on dot button - Shift + Period or Decimal
            else if ((e.KeyCode == Keys.Decimal) ||
                (e.Shift && e.KeyCode == Keys.OemPeriod))
            {
                Dot_Click(sender, e);
            }
            // Click on previous expresion from history button - Open square hook
            else if (e.KeyCode == Keys.OemOpenBrackets)
            {
                History_Click(sender, e);

                if (index > 0)
                {
                    index--;
                    ExpressionFromHistory_Selected(index);
                }
            }
            // Click on next expresion from history button - Closed square hook
            else if (e.KeyCode == Keys.OemCloseBrackets)
            {
                History_Click(sender, e);

                if (index < expressionCount - 1)
                {
                    index++;
                    ExpressionFromHistory_Selected(index);
                }
            }

        }

        /// <summary>
        /// Return digit that key was pressed
        /// </summary>
        /// <param name="key">  Current pressed key </param>
        /// <returns>
        /// <b>  String with digit  </b> - if pressed key was digit key <br/>
        /// <b>  Empty string  </b> - otherside
        /// </returns>
        public string GetDigitByKey(Keys key)
        {
            if (key == Keys.D0 || key == Keys.NumPad0)
            {
                return "0";
            }
            else if (key == Keys.D1 || key == Keys.NumPad1)
            {
                return "1";
            }
            else if (key == Keys.D2 || key == Keys.NumPad2)
            {
                return "2";
            }
            else if (key == Keys.D3 || key == Keys.NumPad3)
            {
                return "3";
            }
            else if (key == Keys.D4 || key == Keys.NumPad4)
            {
                return "4";
            }
            else if (key == Keys.D5 || key == Keys.NumPad5)
            {
                return "5";
            }
            else if (key == Keys.D6 || key == Keys.NumPad6)
            {
                return "6";
            }
            else if (key == Keys.D7 || key == Keys.NumPad7)
            {
                return "7";
            }
            else if (key == Keys.D8 || key == Keys.NumPad8)
            {
                return "8";
            }
            else if (key == Keys.D9 || key == Keys.NumPad9)
            {
                return "9";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Return arithmetic function that key was pressed
        /// </summary>
        /// <param name="key">  Current pressed key </param>
        /// <returns>
        /// <b>  String with arithmetic function  </b> - if pressed key was arithmetic function key <br/>
        /// <b>  Empty string  </b> - otherside
        /// </returns>
        public string GetArithmeticFunctionByKey(Keys key)
        {
            if (key == Keys.Add || key == Keys.Oemplus)
            {
                return "+";
            }
            else if (key == Keys.Divide)
            {
                return "÷";
            }
            else if (key == Keys.Subtract || key == Keys.OemMinus)
            {
                return "-";
            }
            else if (key == Keys.Multiply)
            {
                return "×";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Return triginometric function that key was pressed
        /// </summary>
        /// <param name="key">  Current pressed key </param>
        /// <returns>
        /// <b>  String with triginometric function  </b> - if pressed key was triginometric function key <br/>
        /// <b>  Empty string  </b> - otherside
        /// </returns>
        public string GetTriginometricFunctionByKey(Keys key)
        {
            if (key == Keys.S)
            {
                return "sin";
            }
            else if (key == Keys.C)
            {
                return "cos";
            }
            else if (key == Keys.T)
            {
                return "tan";
            }
            else if (key == Keys.L)
            {
                return "ln";
            }
            else if (key == Keys.E)
            {
                return "exp";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Resize font expression, if it's needed
        /// </summary>
        private void InputText_Changed(object sender, EventArgs e)
        {
            System.Drawing.Size size = TextRenderer.MeasureText(input.Text, input.Font);

            float tempFontSize = input.Font.SizeInPoints;

            while (input.Width >= size.Width && input.Size.Height < input.MaximumSize.Height)
            {
                tempFontSize += 1;

                input.Font = new System.Drawing.Font(input.Font.FontFamily, 
                    tempFontSize, System.Drawing.FontStyle.Regular);

                size = TextRenderer.MeasureText(input.Text, input.Font);
            }

            while (input.Width < size.Width)
            {
                tempFontSize -= 1;

                input.Font = new System.Drawing.Font(input.Font.FontFamily,
                    tempFontSize, System.Drawing.FontStyle.Regular);

                size = TextRenderer.MeasureText(input.Text, input.Font);
            }
        }

        /// <summary>
        /// Resize font previous expression, if it's needed
        /// </summary>
        private void PreviousExpressionText_Changed(object sender, EventArgs e)
        {
            System.Drawing.Size size = TextRenderer.MeasureText(previousExpression.Text, previousExpression.Font);

            float tempFontSize = previousExpression.Font.SizeInPoints;

            while (previousExpression.Width >= size.Width && 
                previousExpression.Size.Height < previousExpression.MaximumSize.Height)
            {
                tempFontSize += 1;

                previousExpression.Font = new System.Drawing.Font(previousExpression.Font.FontFamily,
                    tempFontSize, System.Drawing.FontStyle.Regular);

                size = TextRenderer.MeasureText(previousExpression.Text, previousExpression.Font);
            }

            while (input.Width < size.Width)
            {
                tempFontSize -= 1;

                previousExpression.Font = new System.Drawing.Font(previousExpression.Font.FontFamily, 
                    tempFontSize, System.Drawing.FontStyle.Regular);

                size = TextRenderer.MeasureText(previousExpression.Text, previousExpression.Font);
            }
        }

        
        /// <summary>
        /// Clear status message <br/>
        /// Invoke when timer is end
        /// </summary>
        private void ClearStatusMessage(object sender, EventArgs e)
        {
            Timer_5s.Stop();
            status.Text = null;
        }
    }
}
