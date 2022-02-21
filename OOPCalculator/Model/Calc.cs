using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCalculator
{
    class Calc
    {
        public double Addition(double numberOne,double numberTwo)
        {
            return numberOne + numberTwo;

        }
        public double Subtraction(double numberOne,double numberTwo)
        {
            return numberOne - numberTwo;          

        }
        public double Multiplication(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }
        
        public double Division(double numberOne,double numberTwo)
        {
            if (numberTwo==0)
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
                sum = Addition(sum, term);
            }
            return sum;
        }
        public double Subtraction(double[] numbers)
        {
            double diff = 0;
            foreach (double term in numbers)
            {
                diff = Subtraction(diff, term);
            }
            return diff;
        }

    }
}
