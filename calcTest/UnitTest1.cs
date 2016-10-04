using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc_ikolotov;

namespace calcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void sumTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Sum(x, y);

            Assert.IsTrue(sum == 30);
        }

        [TestMethod]
        public void divTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 2);
        }

        [TestMethod]
        public void divZeroTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 20;
            int y = 0;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 0);
        }

        [TestMethod]
        public void mulTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Multiply(x, y);

            Assert.IsTrue(sum == 200);
        }

        [TestMethod]
        public void powTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 2;
            int y = 10;
            var sum = test.Pow(x, y);

            Assert.IsTrue(sum == 1024);
        }

        [TestMethod]
        public void powZeroTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 2;
            int y = 0;
            var sum = test.Pow(x, y);

            Assert.IsTrue(sum == 1);
        }

        [TestMethod]
        public void powOneTest()
        {
            var test = new Calc_ikolotov.Helper();
            int x = 2;
            int y = 1;
            var sum = test.Pow(x, y);

            Assert.IsTrue(sum == 2);
        }
    }
}
