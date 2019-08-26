using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        NewProgram CApp = new NewProgram();

        [TestMethod]
        public void Add_Emptystring_Zero()
        {
            var result = CApp.AddOperation("");
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Add_Singlenumber_ReturnsThatNumber()
        {
            var result = CApp.AddOperation("1");
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Add_Twonumbers_SumsThem()
        {
            var result = CApp.AddOperation("1,2");
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Add_Newlinebetweennumbers_Treatsasseperator()
        {
            var result = CApp.AddOperation("1\n2");
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Add_Newline_Zero()
        {
            var result = CApp.AddOperation("\n");
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Add_Negative_Throws()
        {
            var result = CApp.AddOperation("-1");
        }
        [TestMethod]
        public void Add_NumberMorethan1000_Ignored()
        {
            var result = CApp.AddOperation("2,1001");
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Add_Multipledelimiters_Allused()
        {
            var result = CApp.AddOperation("//[H][m]\n1K2p3");
            Assert.AreEqual(6, result);
        }

    }
}
