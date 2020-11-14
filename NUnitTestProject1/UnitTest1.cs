using ConsoleApp1;
using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    [TestFixture()]
    public class FunctionsTests
    {
        [TestCase()]
        public void DivTest()
        {
            Functions f = new Functions();
            try
            {
                Assert.Equals(f.Div(1, 1), 1);
                f.Div(1, 0);
            }
            catch (Exception e)
            {
                ExeptionManager.Handle(e);
            }

            try
            {
                Assert.Equals(ExeptionManager.notFatal, 1);
            }
            catch (Exception e) { ExeptionManager.Handle(e); }
        }

        [TestCase(-1, 1, -1)]
        [TestCase(-4, 2, -2)]
        [TestCase(50, 5, 10)]
        public void DivTest(int a, int b, int c)
        {
            try
            {
                Functions f = new Functions();
                Assert.Equals(f.Div(a, b), c);
            }
            catch (Exception e) { ExeptionManager.Handle(e); }

            try
            {
                Assert.Equals(ExeptionManager.notFatal, 1);
            }
            catch (Exception e) { ExeptionManager.Handle(e); }
        }

        [TestCase()]
        public void readFileTest()
        {
            try
            {
                Functions f = new Functions();
                f.readFile("www.txt");
            }
            catch (Exception e) { ExeptionManager.Handle(e); }

            try
            {
                Assert.Equals(ExeptionManager.fatal, 1);
            }
            catch (Exception e) { ExeptionManager.Handle(e); }
        }

        [TestCase()]
        public void MassTest()
        {
            try
            {
                Functions f = new Functions();
                Assert.Equals(f.Mass(4, 2), 2);
                f.Mass(3, 6);
            }
            catch (Exception e) { ExeptionManager.Handle(e); }

            try
            {
                Assert.Equals(ExeptionManager.notFatal, 1);
            }
            catch (Exception e) { ExeptionManager.Handle(e); }
        }
    }
}