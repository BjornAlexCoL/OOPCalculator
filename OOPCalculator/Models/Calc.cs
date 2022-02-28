using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCalculator.Models
{
    public class Calc
    {
        public double Addition(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }
        public double Subtraction(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }
        public double Multiplication(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }

        public double Division(double numberOne, double numberTwo)
        {
            if (numberTwo == 0)
            {
                throw new DivideByZeroException("You can't divide a number with zero");
            }
            return numberOne / numberTwo;
        }
        public double Addition(double[] numbers)
        {
            double sum = 0;
            foreach (double term in numbers)
            {
                sum += term;
            }
            return sum;
        }
        public double Subtraction(double[] numbers)
        {
            double diff = (numbers.Length > 0) ? numbers[0] : 0;
            for (int index = 1; index < numbers.Length; index++)
            {
                diff -=  numbers[index];
            }
            return diff;
        }

    }
}
