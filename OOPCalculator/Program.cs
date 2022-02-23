using System;
using System.Collections.Generic;
using System.Text;
using OOPCalculator.Models;

namespace OOPCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calculator = new Calc();
            List<double> numbers = new List<double>() { };
            StringBuilder operators = new StringBuilder() { };

            string expression = InputExpression(operators, numbers);
            double result = CalculateExpression(operators, numbers);
            Console.Clear();
            Console.WriteLine($"Expression={expression}");
            Console.WriteLine($"Result={result}");

            //Console.WriteLine("{0}", calculator.Addition(new double[] { 1.1, -3.3, 5, 7, 8.8 }));
            //Console.WriteLine("{0}", calculator.Addition(1.1, -3.3));
            /*
            try
            {
                Console.WriteLine("{0}", calculator.Division(1.1, 0));
            }
            catch(DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            */
        }

        static string InputExpression(StringBuilder operators, List<double> numbers)
        {
            string validOperators = "+-*/=\r";
            string validnumbers = "0123456789.,";
            string expression = "";
            string numString = "";
            char inpChar;

            int index = 1;
            do
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Entered expression :");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{expression}{numString}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Please input number {index}: ");

                inpChar = Console.ReadKey().KeyChar;

                if (validOperators.Contains(inpChar))
                {
                    expression += numString + inpChar;
                    operators.Append(inpChar);
                    if (CheckDouble(numString))
                    {
                        numbers.Add(double.Parse(numString));
                        index++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{numString}That is not a number! Try again.");
                        Console.ResetColor();
                    }
                    numString = "";
                }
                else
                {
                    inpChar = (inpChar == '.') ? ',' : inpChar;
                    if (validnumbers.Contains(inpChar))
                    {
                        numString += inpChar;
                    }
                }
            }
            while (inpChar != '=' && inpChar != '\r');
            Console.WriteLine("kalle anka" + expression);
            return expression;
        }
        static double CalculateExpression(StringBuilder operators, List<double> numbers)
        {
            Calc Calculator = new Calc();
            double result = 0;
            double priorityResult = 0;
            for (int index = operators.Length -1; index >= 0; index--)
            {
                switch (operators[index])
                {
                    case '*':
                        priorityResult = Calculator.Multiplication((priorityResult == 0) ? numbers[index] : 1, numbers[index + 1]);
                        break;
                    case '/':
                        try { 
                        priorityResult = Calculator.Division(numbers[index],(priorityResult == 0) ? numbers[index+1] : priorityResult);
                        }
                        catch (DivideByZeroException exception)
                        {
                            //Console.WriteLine(exception.Message);
                        }
                break;
                    case '+':
                        result = Calculator.Addition(numbers[index], (priorityResult == 0) ? numbers[index+1] : priorityResult);
                        priorityResult = 0;
                        break;
                    case '-':
                        result -= Calculator.Subtraction(numbers[index - 1], (priorityResult == 0) ? numbers[index] : priorityResult);
                        priorityResult = 0;
                        break;
                    case '\r':
                    case '=':
                        break;
                }
            }
            return result + priorityResult;
        }

        static bool CheckDouble(string inpStr)
        {
            bool validDouble = true;
            double number;
            try
            {
                number = double.Parse(inpStr ?? "");
            }
            catch
            {
                validDouble = false;
            }//catch end
            return validDouble;
        }
    }
}



