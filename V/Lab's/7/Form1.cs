using System;
using System.Linq;
using System.Windows.Forms;

namespace OOP__IV__Lab_7_WF
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Previuos expression
        /// </summary>
        private string prevExp = string.Empty;
        private string expression = string.Empty;
        private string[] expressionHistory = new string[0];

        private int index;


        public Form1()
        {
            InitializeComponent();
        }


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

        private void Hook_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            expression += " " + clickedButton.Text;

            Expression_Changed();
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            if (expression.Length == 0)
            {
                return;
            }

            string number = GetNumberAtTheEnd();

            if (number.IndexOf(".") != -1 || number.Length == 0)
            {
                return;
            }

            expression += ".";

            Expression_Changed();
        }

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

        private void ClearEverything_Click(object sender, EventArgs e)
        {
            expression = previousExpression.Text = string.Empty;

            Expression_Changed();
        }

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
                Calculator.SetExpression(expression);
                input.Text = Calculator.GetAnswer().ToString().Replace(",", ".").Replace("не число", "Бесконечность");

                prevExp = expression;
                previousExpression.Text = ConvertToNormalViev(expression);
                History_Append(expression);

                expression = input.Text;
            }
            catch
            {
                previousExpression.Text = "Ошибка!";
                return;
            }
        }

        private void History_Click(object sender, EventArgs e)
        {
            history.Items.Clear();

            for (int i = expressionHistory.Length - 1; i >= 0; i--)
            {
                history.Items.Add(ConvertToNormalViev(expressionHistory[i]));
            }
        }


        /// <summary>
        /// Show global var "expression" in "input" textBox
        /// </summary>
        public void Expression_Changed()
        {
            input.Text = ConvertToNormalViev(expression);
        }

        public void ExpressionFromHistory_Selected(int index)
        {
            if (expressionHistory.Length == 0)
            {
                return;
            }

            previousExpression.Text = prevExp = string.Empty;

            expression = expressionHistory[expressionHistory.Length - 1 - index].ToString();

            Expression_Changed();
        }

        private void SelectedIndex_Changed(object sender, EventArgs e)
        {
            ExpressionFromHistory_Selected(history.SelectedIndex);
        }

        public bool IsNumber()
        {
            return 
                expression.EndsWith("+") || expression.EndsWith("m") || 
                expression.EndsWith("/") || expression.EndsWith("*") ||
                expression.EndsWith("(") || expression.EndsWith(" ") ||
                expression.EndsWith("^") || expression.Length == 0;
        }

        public bool IsArithmeticFunction()
        {
            return 
                expression.EndsWith(")") || expression.EndsWith("n") ||
                expression.EndsWith("s") || expression.EndsWith("p");
        }

        private void PreviousExpression_MouseHover(object sender, EventArgs e)
        {
            previousExpression.ForeColor = input.ForeColor;
        }

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

        private void PreviousExpression_MouseLeave(object sender, EventArgs e)
        {
            previousExpression.ForeColor = System.Drawing.Color.Silver;
        }

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

        public void History_Append(string item)
        {
            if (expressionHistory.Contains(item))
            {
                expressionHistory.SetValue(expressionHistory.Last().ToString(), Array.IndexOf(expressionHistory, item));
                expressionHistory.SetValue(item, expressionHistory.Length - 1);
            }
            else
            {
                expressionHistory = expressionHistory.Append(item).ToArray();
            }
        }

        public string ConvertToNormalViev(string str)
        {
            if (str.Length == 0)
            {
                return "0";
            }
            else
            {
                return str.Replace("-1 *", "-").Replace("m", "-").Replace(" ", "");
            }
        }

        // Hotkeys
        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.D0)
            {
                Button clickenButton = new Button();
                clickenButton.Text = ")";

                Hook_Click(clickenButton, e);
            }
            else if (e.Shift && e.KeyCode == Keys.D9)
            {
                Button clickenButton = new Button();
                clickenButton.Text = "(";

                Hook_Click(clickenButton, e);
            }
            else if (e.Control && e.KeyCode == Keys.Back)
            {
                PreviousExpression_Click(sender, e);
            }
            else if (e.Shift && e.KeyCode == Keys.D6)
            {
                Button clickenButton = new Button();
                clickenButton.Text = "^";

                ArithmeticFunction_Click(clickenButton, e);
            }
            else if (GetDigitByKey(e.KeyCode) != string.Empty)
            {
                Button clickenButton = new Button();
                clickenButton.Text = GetDigitByKey(e.KeyCode);

                Digit_Click(clickenButton, e);
            }
            else if (GetArithmeticFunctionByKey(e.KeyCode) != string.Empty)
            {
                Button clickenButton = new Button();
                clickenButton.Text = GetArithmeticFunctionByKey(e.KeyCode);

                ArithmeticFunction_Click(clickenButton, e);
            }
            else if (GetTriginometricFunctionByKey(e.KeyCode) != string.Empty)
            {
                Button clickenButton = new Button();
                clickenButton.Text = GetTriginometricFunctionByKey(e.KeyCode);

                TriginometricFunction_Click(clickenButton, e);
            }
            else if (e.Shift && e.KeyCode == Keys.Back)
            {
                ClearEverything_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Back)
            {
                Clear_Click(sender, e);
            }
            else if ((e.Shift && e.KeyCode == Keys.Enter) || 
                (e.Shift && e.KeyCode == Keys.Return) ||
                e.KeyCode == Keys.R)
            {
                GetAnswer_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.Decimal) ||
                (e.Shift && e.KeyCode == Keys.OemPeriod))
            {
                Dot_Click(sender, e);
            }
            else if (e.KeyCode == Keys.OemOpenBrackets)
            {
                History_Click(sender, e);

                if (index > 0)
                {
                    index--;
                    ExpressionFromHistory_Selected(index);
                }
            }
            else if (e.KeyCode == Keys.OemCloseBrackets)
            {
                History_Click(sender, e);

                if (index < expressionHistory.Length - 1)
                {
                    index++;
                    ExpressionFromHistory_Selected(index);
                }
            }

        }

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
    }
}
