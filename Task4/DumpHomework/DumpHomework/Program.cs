using System;

namespace DumpHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "1123";
            bool isExpressionCorrect = true;

            int num = 0;
            if (expression.Contains("+"))
            {
                num = expression.IndexOf("+");
            }
            else if (expression.Contains("-"))
            {
                num = expression.IndexOf("-");
            }
            else if (expression.Contains("*"))
            {
                num = expression.IndexOf("*");
            }
            else if (expression.Contains("/"))
            {
                num = expression.IndexOf("/");
            }

            double num2 = 0;
            double num3 = 0;
            isExpressionCorrect = num != 0 && double.TryParse(expression.Substring(0, num), out num2) &&
                                  double.TryParse(expression.Substring(num + 1, expression.Length - num - 1),

                                      out num3);
            if (!isExpressionCorrect)
            {
                expression = "Incorrect Expression";
            }
            else
            {
                string text = expression.Substring(num, 1);

                switch (text)
                {
                    case "+":
                    {
                        expression = expression + "=" + (num2 + num3);
                        break;
                    }
                    case "-":
                    {
                        expression = expression + "=" + (num2 - num3);
                        break;
                    }
                    case "*":
                    {
                        expression = expression + "=" + num2 * num3;
                        break;
                    }
                    default:
                    {
                        expression = expression + "=" + num2 / num3;
                        break;
                    }
                }
            }
        }
    }
}
