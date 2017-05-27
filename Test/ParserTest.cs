using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parse;

namespace Test {
    [TestClass]
    public class ParserTest {
        [TestMethod]
        public void numberUnitTest() {
            Parser p = new Parser("2.325*3.5*4*5");
            double expected = 2.325;
            double actual = p.factor();

            Assert.AreEqual(expected, actual, "The number was not correcty parsed.");
        }

        [TestMethod]
        public void factorUnitTest() {
            Parser p = new Parser("2.5*4/2+1");
            double expected = 5;
            double actual = p.term();

            Assert.AreEqual(expected, actual, "Factor incorrectly calculated.");
        }

        [TestMethod]
        public void expressionUnitTest() {
            Parser p = new Parser("2.5*4/2+1/2");
            double expected = 5.5;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, "Expression incorrectly evaluated.");
        }

        [TestMethod]
        public void bracketsUnitTest() {
            Parser p = new Parser("(2.5*4)");
            double expected = 10;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, "Bracket detection broken.");
        }

        [TestMethod]
        public void multipleBracketsUnitTest() {
            Parser p = new Parser("(((2.5*4)))");
            double expected = 10;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, "Mutlibracket detection failed");
        }

        [TestMethod]
        public void recursiveDescentUnitTest() {
            Parser p = new Parser("2.5*4+2*(1+4)*10");
            double expected = 110;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, "Recursive Descent Failed.");
        }

        [TestMethod]
        public void basicParseTest() {
            Parser p = new Parser("1+3.4*2*(2*6-1)/3-2.12*8.25");
            double expected = 8.44333333;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, 0.000001, "Basic Parse Failed");
        }

        [TestMethod]
        public void exponentTest() {
            Parser p = new Parser("2^3");
            double expected = 8;
            double actual = p.exponent();

            Assert.AreEqual(expected, actual, "Exponent Failed.");
        }

        [TestMethod]
        public void exponentExpressionTest() {
            Parser p = new Parser("1+2^3/2");
            double expected = 5;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, "Exponent Failed.");
        }

        [TestMethod]
        public void intermediateParseTest() {
            Parser p = new Parser("1-2+(1*5+4)^2.5/2+5*2");
            double expected = 130.5;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, "Parse Failed.");
        }

        [TestMethod]
        public void advanceParseTest() {
            Parser p = new Parser("2*(2+(1*2))^2");
            double expected = 32;
            double actual = p.expression();

            Assert.AreEqual(expected, actual, 0.01, "Parse Failed.");
        }
    }
}
