using System;
using System.Collections.Generic;
using System.Text;
using OOPCalculator.Models;
using Xunit;

namespace OOPCalculator.Tests.Models
{
    public class CalcTest
    {
        [Theory]
        [InlineData(10, 10, 100)]
        [InlineData(10, -10, -100)]
        [InlineData(-5, -10, 50)]
        [InlineData(-10, -10, 100)]
        [InlineData(-10, 0, 0)]
        public void MultiplicationTest(double numberOne, double numberTwo, double expected)
        {
            //Assign
            Calc calculator = new Calc();
            //Act
            double result = calculator.Multiplication(numberOne, numberTwo);
            //Assert
            Assert.Equal(expected, result, 2);
        }
        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(10, -10, -1)]
        [InlineData(-5, -10, 0.5)]
        [InlineData(-10, -10, 1)]
        public void DivisionTest(double numberOne, double numberTwo, double expected)
        {
            //Assign
            Calc calculator = new Calc();
            //Act
            double result = calculator.Division(numberOne, numberTwo);
            //Assert
            Assert.Equal(expected, result, 2);
        }
        [Theory]
        [InlineData(10, 0, "You can't divide a number with zero")]
        [InlineData(10, 1, "")]
        public void ZeroDivisionTest(double numinator, double denuminator, string expected)
        {
            //Assign
            Calc calculator = new Calc();
            string message = "";
            //Act
            try
            {
                calculator.Division(numinator, denuminator);
            }
            //Assert
            catch (DivideByZeroException exception)
            {
                message = exception.Message;
            }
            finally
            {
                Assert.Equal(message, expected);
            }



        }
        [Theory]
        [InlineData(new double[] { 5.2, 9.8, 3, 4 }, 22)]
        [InlineData(new double[] { 1.1, -3.3, 5, 7, 8.8 }, 18.6)]
        [InlineData(new double[] { 0, 5.7, 8, 9, 10, 11, 12 }, 55.7)]
        public void AdditionArrayTest(double[] array, double expected)
        {
            //Assign
            Calc calculator = new Calc();

            //Act
            double sum = calculator.Addition(array);
            //Assert
            Assert.Equal(expected, sum, 2);
        }

        [Theory]
        [InlineData(new double[] { 5.2, 9.8, 3, 4 },-11.6)]
        [InlineData(new double[] { 1.1, -3.3, 5, 7, 8.8 },-16.4)]
        [InlineData(new double[] { 0, 5.7, 8, 9, 10, 11, 12 }, -55.7)]
        [InlineData(new double[] { -2.2, 5.5, -8.2, 61.1 }, -60.6)]
        [InlineData(new double[] { -2.2 }, -2.2)]
        public void SubtractionArrayTest(double[] array, double expected)
        {
            //Assign
            Calc calculator = new Calc();

            //Act
            double diff = calculator.Subtraction(array);
            //Assert
            Assert.Equal(expected, diff, 2);
        }

    }
}
