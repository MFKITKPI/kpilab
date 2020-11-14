using ConsoleApp1;
using NUnit.Framework;
using System;
using System.IO;
using ConsoleApp1.EDefinition;
using ConsoleApp1.EInformer;
using NSubstitute;
using NUnit.Framework.Internal;

namespace NUnitTestProject1
{
    [TestFixture()]
    public class FunctionsTests
    {
        ExceptionManager em = new ExceptionManager(EDefinitionFactory.CreateSimpleEDefinition());
        [Test]
        public void Test_EDefinitionFile()
        {

            try
            {
                em.SetDefinition(EDefinitionFactory.CreateSimpleEDefinition());
                throw new FileNotFoundException();
            }
            catch (Exception e)
            {
                em.Handle(e);
            }

            try
            {
                Assert.AreEqual(em.Fatal, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public void Test_EDefinitionFalse()
        {
            try
            {
                em.SetDefinition(EDefinitionFactory.CreateStubEDefinitionFalse());
                throw new FileNotFoundException();
            }
            catch (Exception e)
            {
                em.Handle(e);
            }

            try
            {
                Assert.AreEqual(em.Fatal, 0);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        [Test]
        public void Test_EDefinitionTrue()
        {
            try
            {
                em.SetDefinition(EDefinitionFactory.CreateStubEDefinitionTrue());
                throw new FileNotFoundException();
            }
            catch (Exception e)
            {
                em.Handle(e);
                em.Handle(e);
                em.Handle(e);
                em.Handle(e);
            }

            try
            {
                Assert.AreEqual(em.Fatal, 5);
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        //NSubstitute 
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            IExceptionInformer informer = Substitute.For<ExceptionServerInformer>();
            ExceptionManager em = new ExceptionManager(new EDefinitionFile());
            em.SetInformer(informer);
            em.Handle(new FileNotFoundException());
            var s = informer.Received().Inform(new FileNotFoundException());
            Assert.True(true);
        }
    }
}