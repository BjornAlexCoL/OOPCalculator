using System;
using System.Collections.Generic;
using System.Text;
using OOPCalculator;
using Xunit;

namespace OOPCalculator.Tests
{
    public class ProgramTest
    {

        //[Fact]
        //public string InputExpression(StringBuilder operators, List<double> numbers)

        [Theory]
        //[InlineData("5+5",10)]
        //[InlineData("5-5",0)]
        //[InlineData("1+2*3",7)]
        //[InlineData("1/0",0)]
        //[InlineData("15+14*2-14/2",36)]
        //[InlineData("15++",15)]
        //[InlineData("-2,2-5,5--8,2-61.1",-60.6)]
        [InlineData("(5)",5)]
        public void CalculateExpressionTest(string expression, double expected)
        {
            //Assign
            Program program = new Program();
            double result;
            //act
            result = program.CalculateExpression(expression);
            //assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("5+5",true)]
        [InlineData("5-5", true)]
        [InlineData("1+2*3", true)]
        [InlineData("1/0", true)]
        [InlineData("15+14*2-14/2", true)]
        [InlineData("15++",false)]
        [InlineData("-2,2-5,5--8,2-61.1",true)]
        public void DecodeExpressionTest(string expression, bool expected)
        {
            
            //Assign
            Program program = new Program();
            double result;
            //act
            result = program.DecodeExpression(expression);
            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("X", false)]
        [InlineData("14", true)]
        [InlineData("13,7", true)]
        [InlineData("-14", true)]
        [InlineData("0", true)]
        [InlineData("", false)]
        public void CheckDoubleTest(string inpStr, bool expected)
        {
            //Assign
            Program program = new Program();
            //act
            bool result = program.CheckDouble(inpStr);
            //assert
            Assert.Equal(result, expected);
        }


    }
}
