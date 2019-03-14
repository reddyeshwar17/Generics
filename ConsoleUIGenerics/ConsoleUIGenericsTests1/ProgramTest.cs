using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleUIGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUIGenerics.Tests
{
    [TestClass()]
    public class ProgramTest
    {
        [TestMethod()]
        public void CombineStringTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CombineString_Positive()
        {
            string[] actual = new string[] { "Today", "is", "wonderful", "day", "in", "my", "life" };
            string expected = "Today is wonderful day in my life";
            Program program = new Program();
            PrivateObject obj = new PrivateObject(program);
            string actualResult = program.CombineString(actual);
            Assert.AreEqual<string>(expected, actualResult);
        }
    }
}