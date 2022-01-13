using Delegates_Events_Exception_tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExceptionUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Catch_ArgumentException_Test()
        {
            Assert.ThrowsException<ArgumentException>(()=>ExceptionHelper.CheckBoolExpression<ArgumentException>(10 == 10, "Exception: " + typeof(ArgumentException)), "Expected Exception");
        }

        [TestMethod]
        public void Catch_NullReferenceException_Test()
        {
            Assert.ThrowsException<NullReferenceException>(() => ExceptionHelper.CheckBoolExpression<NullReferenceException>("hi" != null, "Exception: " + typeof(NullReferenceException)), "Expected Exception");
        }

        [TestMethod]
        public void Catch_Exception_Test()
        {
            bool condition = true;
            Assert.ThrowsException<Exception>(() => ExceptionHelper.CheckBoolExpression<Exception>(condition, "Exception: " + typeof(Exception)), "Expected Exception");
        }

        [TestMethod]
        public void No_Exception_Test()
        {
            bool condition = false;
            try
            {
                ExceptionHelper.CheckBoolExpression<NullReferenceException>(condition, "Exception: " + typeof(NullReferenceException));
            }
            catch (Exception)
            {
                Assert.Fail("Exception occurs");
            }
        }

        
    }
}
