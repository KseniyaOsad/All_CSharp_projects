using LINQ_tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class HelperUnitTest
    {
        [TestMethod]
        public void Compare_WhereWithMyWhere_ReturnTrue()
        {
            List<int> i = new List<int>(Enumerable.Range(1, 10));
            var query1 = i.Where(x => x % 2 == 0);
            var query2 = i.MyWhere(x => x % 2 == 0);
            i.Add(12);
            i.Add(14);
            Assert.IsTrue(query1.SequenceEqual(query2));
        }
    }
}
