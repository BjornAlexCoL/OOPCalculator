using System;
using System.Collections.Generic;
using System.Text;
using OOPCalculator.Models;

namespace OOPCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartCalculator();
        }

        private static void StartCalculator()
        {
            //string expression = InputExpression();
            //double result = CalculateExpression(expression);
            //Console.Clear();
            //Console.WriteLine($"Expression={expression}");
            //Console.WriteLine($"Result={result}");

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

        public string InputExpression()
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
                    if (CheckDouble(numString))
                    {
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
        public double DecodeExpression(string expression)
        {
            string validOperators = "+-*/()=\r";
            string validnumbers = "0123456789.,";
            string numString = "";
            char operand;
            bool decodedExpression = false;
            double result=0;
            for (int index = expression.Length - 1; index >= 0; index--)
            {
                 if (validOperators.Contains(expression[index]))
                        {
                                
                        switch (expression[index])
                            {
                            case ')':
                            try
                            {
                            index = expression.IndexOf('(');
                            result += DecodeExpression(expression.Substring(index + 1, (expression.LastIndexOf(')') - 1) - index));
                            }
                            catch (ArithmeticException exception)
                            {
                            //Console.WriteLine(exception.Message);
                                throw new ArithmeticException("Wrong number of paranteses");//Console.WriteLine(exception.Message);
                            }
                            break;
                    case '*':
                            
                        priorityResult = calculator.Multiplication((priorityResult == 0) ? numbers[index] : 1, numbers[index + 1]);
                        break;
                    case '/':
                        try
                        {
                            priorityResult = calculator.Division(numbers[index], (priorityResult == 0) ? numbers[index + 1] : priorityResult);
                        }
                        catch (DivideByZeroException exception)
                        {
                            return 0;
                        }
                        break;
                    case '+':
                        result = calculator.Addition(numbers[index], (priorityResult == 0) ? numbers[index + 1] : priorityResult);
                        priorityResult = 0;
                        break;
                    case '-':
                        result -= calculator.Subtraction(numbers[index - 1], (priorityResult == 0) ? numbers[index] : priorityResult);
                        priorityResult = 0;
                        break;
                    case '\r':
                    case '=':
                        break;

                                operators.Append(inpChar);
                                if (CheckDouble(numString))
                                {
                                    numbers.Add(double.Parse(numString));
                                    index++;
                                }
                                else
                                {
                                    throw new ArithmeticException("Expression cant be decoded");
                                }
                                numString = "";
                            }
                            else
                            {
                                if (validnumbers.Contains(inpChar))
                                {
                                    numString += (inpChar == '.') ? ',' : inpChar;
                                }
                            }
                        }
                        /*
                        foreach (char inpChar in expression)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"{expression}{numString}");

                        */
                        return decodedExpression = true;
        }

        public double CalculateExpression(string expression)
        {
            Calc calculator = new Calc();
            List<double> numbers = new List<double>() { };
            StringBuilder operators = new StringBuilder() { };
            bool validExpression = false;
                double result = 0;
                double priorityResult = 0;
            try
            {
                validExpression = DecodeExpression(expression, operators, numbers);
            }
            catch (ArithmeticException exception)
            {
                //Console.WriteLine(exception.message)
                return 0;
            }
            if (validExpression)
            {
                for (int index = operators.Length - 1; index >= 0; index--)
                {
                    switch (operators[index])
                    {
                        case '*':
                            priorityResult = calculator.Multiplication((priorityResult == 0) ? numbers[index] : 1, numbers[index + 1]);
                            break;
                        case '/':
                            try
                            {
                                priorityResult = calculator.Division(numbers[index], (priorityResult == 0) ? numbers[index + 1] : priorityResult);
                            }
                            catch (DivideByZeroException exception)
                            {
                                return 0;
                            }
                            break;
                        case ')':
                            try
                            {
                                index = expression.IndexOf('(');
                                priorityResult = CalculateExpression(expression.Substring(index + 1, (expression.LastIndexOf(')') - 1) - index));
                            }
                            catch (ArithmeticException exception)
                            { 
                                //Console.WriteLine(exception.Message);
                                throw new ArithmeticException("Wrong number of paranteses");//Console.WriteLine(exception.Message);
                            }
                            break;
                        case '+':
                            result = calculator.Addition(numbers[index], (priorityResult == 0) ? numbers[index + 1] : priorityResult);
                            priorityResult = 0;
                            break;
                        case '-':
                            result -= calculator.Subtraction(numbers[index - 1], (priorityResult == 0) ? numbers[index] : priorityResult);
                            priorityResult = 0;
                            break;
                        case '\r':
                        case '=':
                            break;
                    }
                }

            }
            return result + priorityResult;

        }

        public bool CheckDouble(string inpStr)
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



