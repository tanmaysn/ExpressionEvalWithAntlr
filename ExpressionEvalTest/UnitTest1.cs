using System;
using System.Text;
using ExpressionEvalWithAntlr;
using ExpressionEvalWithAntlr.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionEvalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestArrayListParse()
        {
            ArrayListParser parser = new ArrayListParser();
            string output = parser.ParseToString("{99, 56, 754}");

            Assert.AreEqual("(init { (value 99) , (value 56) , (value 754) })", output);
        }

        [TestMethod]
        public void TestArrayListWalk()
        {
            ArrayListParser parser = new ArrayListParser();
            string walk = parser.Walk("{99, 56, 754}");

            Assert.AreEqual("\"\\u0099\\u0056\\u0754\"", walk);
        }

        [TestMethod]
        public void TestCalc()
        {
            Calc calc = new Calc();
            int main = calc.Main("1+2");
            Assert.AreEqual(3, main);
        }

        [TestMethod]
        public void TestCalcComplex()
        {
            StringBuilder builder = new StringBuilder();

            Calc calc = new Calc();
            builder.AppendLine("120");
            builder.AppendLine("a = 199");
            builder.AppendLine("b = 773");
            builder.AppendLine("120 + a * b + 30");

            int main = calc.Main(builder.ToString());
            Assert.AreEqual(153977, main);
        }
    }
}
