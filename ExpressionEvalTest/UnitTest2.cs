using System;
using System.Collections.Generic;
using ExpressionEvalWithAntlr.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionEvalTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ExpressionTestString()
        {
            var evaluator = new Evaluator();
            Dictionary<string, object> value = evaluator.GetStringValue("val eq 2" + Environment.NewLine);
            
            Assert.AreNotEqual(null, value);
            Assert.AreEqual(1, value.Count);
        }

        [TestMethod]
        public void ExpressionTestStringComplex()
        {
            var evaluator = new Evaluator();
            Dictionary<string, object> value = evaluator.GetStringValue("val eq 2 and val2 neq 2" + Environment.NewLine);

            Assert.AreNotEqual(null, value);
            Assert.AreEqual(2, value.Count);
        }

        [TestMethod]
        public void ExpressionTestStringComplex2()
        {
            var evaluator = new Evaluator();
            Dictionary<string, object> value = evaluator.GetStringValue("val = 2 and val2 geq xyz or (abc neq deq)" + Environment.NewLine);

            Assert.AreNotEqual(null, value);
            Assert.AreEqual(3, value.Count);
            Assert.AreEqual("2", value["val"]);
            Assert.AreEqual("xyz", value["val2"]);
            Assert.AreEqual("deq", value["abc"]);
        }
    }
}
