using System;


namespace OOPCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calculator = new Calc();

            Console.WriteLine("{0}", calculator.Addition(new double[] { 1.1, -3.3, 5, 7, 8.8 }));
            Console.WriteLine("{0}", calculator.Addition(1.1, -3.3));
            Console.WriteLine("{0}", calculator.Division(1.1, 0));

        }
    }
}
