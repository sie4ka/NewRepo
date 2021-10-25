using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ZPowerLibrary;
namespace ZPowerTestProject
{
    [TestClass]
    public class ZPowerUnitTest
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var number = CreateTestZPower();

            Assert.AreEqual(12.1, number.Base);
            Assert.AreEqual(2 * Math.Pow(10, -13), number.Exponent * Math.Pow(10, -13));
            Assert.AreEqual(146.41 * Math.Pow(10, -13), number.Value * Math.Pow(10, -13));
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            Assert.AreEqual("12,1E2", CreateTestZPower().ToString());
        }

        [TestMethod]
        public void DisplayTestMethod()
        {
            var numb = CreateTestZPower();
            var diff = new ZPower(-75.6, -12);

            var consoleOut = new[]
            {
                "Структура ZPower, 12,1E2",
                "Структура ZPower, -75,6E-12",
            };

            TextWriter oldOut = Console.Out;

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            numb.Display();
            diff.Display();

            Console.SetOut(oldOut);

            var outputArray = output.ToString().Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(2, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        [TestMethod]
        public void EqualsTestMethod()
        {
            ZPower p1 = new ZPower(12.1, 2);

            ZPower p2 = new ZPower(-12.1, 2);

            Assert.AreEqual(true, p1.Equals(p2));
        }

        [TestMethod]
        public void MultiplyTestMethod()
        {
            ZPower p1 = new ZPower(14.4, 5);

            ZPower p2 = new ZPower(14.4, 1);

            var p3 = p1 * p2;

            Assert.AreEqual("14,4E6", p3.ToString());
        }

        [TestMethod]
        public void DivideTestMethod()
        {
            ZPower p1 = new ZPower(14.4, 5);

            ZPower p2 = new ZPower(14.4, 1);

            var p3 = p1 / p2;

            Assert.AreEqual("14,4E4", p3.ToString());
                
        }
        private ZPower CreateTestZPower()
        {
            return new ZPower(12.1, 2);
        }
    }

}
