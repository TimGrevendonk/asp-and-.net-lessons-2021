using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorkata;
using System;

namespace StringCalculatorkataTest
{
    // Mandatory annotation for any class that contains test methods.
    [TestClass]
    public class StringCalculatorTest
    {
        /*
        AreEqual = for variables
        areSame = for Objects

        naming convention ==
        TestedMethod_InitialState_ExpectedState()
        */

        // Mandatory annotation for any test method.
        [TestMethod]
        public void Add_EmptyStringAsParam_ReturnsZero()
        {
            // Arrange.[initialize data]
                // string empty = String.empty // .empty puts a null value as parameter.

            // Act. [Method calls]
                //int result = String.Add(empty)

            // Assert. [Test the result as expected]
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [TestMethod]
        public void Add_StringContainingSingleNumber_ReturnsTheNumberItself()
        {
            // Arrange.

            // Act.
            // Assert.
            Assert.AreEqual(3, StringCalculator.Add("3"));
        }

        [TestMethod]
        public void Add_TwoNumbersSeparatedByComma_ReturnsTheirSum()
        {
            // Arrange.

            // Act.

            // Assert.
            Assert.AreEqual(8, StringCalculator.Add("4,4"));
        }

        [DataTestMethod]
        [DataRow(18, "4,4,3,7")]
        [DataRow(10, "1,2,3,4")]
        [DataRow(15, "1,2,3,4,5")]
        [DataRow(1006, "1,2,3,1000")]
        [DataRow(6, "1,2,3,1001")]
        public void Add_MoreThanThreeNumbersSeparatedByComma_ReturnsTheirSum(int result, string numbers)
        {
            // Arrange.

            // Act.

            // Assert.
            // "result" corresponds to the first item in the DataRow, and the value after the comma to the data array itself. 
            Assert.AreEqual(result, StringCalculator.Add(numbers));
        }

        // Test of custom Throw exception.
        [DataTestMethod]
        [DataRow("1,-2,-3")]
        [DataRow("4,-4,3,7")]
        [DataRow("-4,-3,-7")]
        public void Add_StringContainingNegativeNumbers_ThrowsException(string numbers)
        {
            // Arrange.

            // Act.

            // Assert.
            Assert.ThrowsException<NegativeNumberException>
            (() => StringCalculator.Add(numbers));
        }
    }
}
