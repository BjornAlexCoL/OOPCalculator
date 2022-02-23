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
        [Fact]
        public void AdditionArrayTest()
        {
            //Assign
             Calc calculator = new Calc();
            double[] termsOne = new double[] { 5.2, 9.8, 3, 4 };
            double[] termsTwo = new double[] { 1.1, -3.3, 5, 7, 8.8 };
            double[] termsThree = new double[] {0,5.7,8,9,10,11,12};
            double expectedOne = 22;
            double expectedTwo = 18.6;
            double expectedThree = 55.7;

            //Act
            double sumOne = calculator.Addition(termsOne);
            double sumTwo = calculator.Addition(termsTwo);
            double sumThree = calculator.Addition(termsThree);
            //Assert
            Assert.Equal(expectedOne, sumOne,2);
            Assert.Equal(expectedTwo, sumTwo,2);
            Assert.Equal(expectedThree, sumThree,2);
        }
        [Fact]
        public void SubtractionArrayTest()
        {
            //Assign
             Calc calculator = new Calc();
            double[] termsOne = new double[] { 5.2, 9.8, 3, 4 };
            double[] termsTwo = new double[] { 1.1, -3.3, 5, 7, 8.8 };
            double[] termsThree = new double[] {0,5.7,8,9,10,11,12};
            double expectedOne = -22;
            double expectedTwo = -18.6;
            double expectedThree = -55.7;

            //Act
            double diffOne = calculator.Subtraction(termsOne);
            double diffTwo = calculator.Subtraction(termsTwo);
            double diffThree = calculator.Subtraction(termsThree);
            //Assert
            Assert.Equal(expectedOne, diffOne,2);
            Assert.Equal(expectedTwo, diffTwo,2);
            Assert.Equal(expectedThree, diffThree,2);
        }

    }
}
